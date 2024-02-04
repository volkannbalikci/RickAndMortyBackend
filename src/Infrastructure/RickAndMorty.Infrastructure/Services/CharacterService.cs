using RickAndMorty.Application.Abstraction.Services;
using RickAndMorty.Application.RickAndMortyApi.Dtos;
using RickAndMorty.Application.RickAndMortyApi.Models;
using RickAndMorty.Application.Utilities.Pagination.Abstractions;
using RickAndMorty.Application.Utilities.Pagination.Extensions;
using RickAndMorty.Application.Utilities.Pagination.Implementations;
using RickAndMorty.Application.Utilities.Responses.Common;
using RickAndMorty.Application.Utilities.Responses.ContentResponse;
using RickAndMorty.Infrastructure.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RickAndMorty.Infrastructure.Service;

public class CharacterService : ICharacterService
{
    private readonly HttpClient _httpClient;
    private readonly IEpisodeService _episodeService;
    private readonly ILocationService _locationService;

    public CharacterService(HttpClient httpClient, IEpisodeService episodeService, ILocationService locationService)
    {
        _httpClient = httpClient;
        _episodeService = episodeService;
        _locationService = locationService;
    }
    public async Task<IContentResponse<IPagination<GetCharacterDto>>> GetPaginationCharacterDtoAsync(int pageIndex, int pageSize)
    {
        RickAndMortyApiResponseModel<GetCharacterDto> response = new RickAndMortyApiResponseModel<GetCharacterDto>();
        HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync(this.GetAlignedUrl(RickAndMortyConstants.RickAndMortyBaseApiUrlString, RickAndMortyConstants.Character, RickAndMortyConstants.PageIndexEquals(pageIndex)));
        var content = await httpResponseMessage.Content.ReadAsStringAsync();
        response = JsonSerializer.Deserialize<RickAndMortyApiResponseModel<GetCharacterDto>>(content);
        IPagination<GetCharacterDto> pagination = await response.results.ToPaginationAsync<GetCharacterDto>(pageIndex, pageSize, response.info.count);
        return new SuccessfulContentResponse<IPagination<GetCharacterDto>>(pagination, "Listelendi", "Başarılı");
    }


    public async Task<IContentResponse<GetCharacterDetailsDto>> GetCharacterDetailsDtoByIdAsync(int characterId)
    {
        GetCharacterDetailsDto getCharacterDetailsDto = new GetCharacterDetailsDto();
        var response = await this.GetCharacterDtoByIdAsync(characterId);
        GetCharacterDto characterDto = response.Data;

        getCharacterDetailsDto.id = characterDto.id;
        getCharacterDetailsDto.name = characterDto.name;
        getCharacterDetailsDto.status = characterDto.status;
        getCharacterDetailsDto.type = characterDto.type;
        getCharacterDetailsDto.gender = characterDto.gender;
        getCharacterDetailsDto.image = characterDto.image;

        List<GetEpisodeDto> getEpisodeDtoList = new List<GetEpisodeDto>();
        foreach (var episodeId in characterDto.episodeIdList)
        {
            var episodeResponse = await _episodeService.GetEpisodeDtoByIdAsync(Convert.ToInt32(episodeId));
            GetEpisodeDto getEpisodeDto = episodeResponse.Data;
            getEpisodeDtoList.Add(getEpisodeDto);
        }
        getCharacterDetailsDto.episode = getEpisodeDtoList;

        var originResponse = await _locationService.GetLocationDtoByIdAsync(Convert.ToInt32(characterDto.originId));
        GetLocationDto origin = originResponse.Data;
        getCharacterDetailsDto.origin = origin;

        var locationResponse = await _locationService.GetLocationDtoByIdAsync(Convert.ToInt32(characterDto.locationId));
        GetLocationDto location = locationResponse.Data;
        getCharacterDetailsDto.location = location;

        return new SuccessfulContentResponse<GetCharacterDetailsDto>(getCharacterDetailsDto, "Listelendi", "Başarılı");
    }

    public async Task<IContentResponse<GetCharacterDto>> GetCharacterDtoByIdAsync(int characterId)
    {
        HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync(this.GetAlignedUrl(RickAndMortyConstants.RickAndMortyBaseApiUrlString, RickAndMortyConstants.Character, characterId.ToString()));
        var content = await httpResponseMessage.Content.ReadAsStringAsync();
        GetCharacterDto getCharacterDto = JsonSerializer.Deserialize<GetCharacterDto>(content);
        return new SuccessfulContentResponse<GetCharacterDto>(getCharacterDto, "Listelendi", "Başarılı");
    }

    private String GetAlignedUrl(params string[] urlSegments)
    {
        StringBuilder stringBuilder = new StringBuilder();
        foreach (var urlSegment in urlSegments)
        {
            stringBuilder.Append($"{urlSegment}/");
        }

        return stringBuilder.ToString();
    }
}
