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
namespace RickAndMorty.Infrastructure.Services;

public class LocationService : ILocationService
{
    private readonly HttpClient _httpClient;
    private readonly ILocationService _locationService;
    private readonly ICharacterService _characterService;

    public LocationService(HttpClient httpClient, ICharacterService characterService, ILocationService locationService)
    {
        _httpClient = httpClient;
        _characterService = characterService;
        _locationService = locationService;
    }
    public async Task<IContentResponse<GetLocationDto>> GetLocationDtoByIdAsync(int locationId)
    {
        HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync(this.GetAlignedUrl(RickAndMortyConstants.RickAndMortyBaseApiUrlString, RickAndMortyConstants.Location, locationId.ToString()));
        var content = await httpResponseMessage.Content.ReadAsStringAsync();
        GetLocationDto getLocationDto = JsonSerializer.Deserialize<GetLocationDto>(content);
        return new SuccessfulContentResponse<GetLocationDto>(getLocationDto, "Listelendi", "Başarılı");
    }
    public async Task<IContentResponse<GetLocationDetailsDto>> GetLocationDetailsDtoByIdAsync(int locationId)
    {
        GetLocationDetailsDto getLocationDetailsDto = new GetLocationDetailsDto();
        var response = await this.GetLocationDtoByIdAsync(locationId);
        GetLocationDto locationDto = response.Data;

        getLocationDetailsDto.id = locationDto.id;
        getLocationDetailsDto.name = locationDto.name;
        getLocationDetailsDto.type = locationDto.type;
        getLocationDetailsDto.dimension = locationDto.dimension;
        getLocationDetailsDto.url = locationDto.url;
        getLocationDetailsDto.created = locationDto.created;

        List<GetCharacterDto> getCharacterDtoList = new List<GetCharacterDto>();
        foreach (var characterId in locationDto.characterIdList)
        {
            var characterResponse = await _characterService.GetCharacterDtoByIdAsync(Convert.ToInt32(locationId));
            GetCharacterDto getCharacterDto = characterResponse.Data;
            getCharacterDtoList.Add(getCharacterDto);
        }
        getLocationDetailsDto.character = getCharacterDtoList;

        return new SuccessfulContentResponse<GetLocationDetailsDto>(getLocationDetailsDto, "Listelendi", "Başarılı"); ;
    }

    public async Task<IContentResponse<IPagination<GetLocationDto>>> GetPaginationLocationDtoAsync(int pageIndex, int pageSize)
    {
        RickAndMortyApiResponseModel<GetLocationDto> response = new RickAndMortyApiResponseModel<GetLocationDto>();
        HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync(this.GetAlignedUrl(RickAndMortyConstants.RickAndMortyBaseApiUrlString, RickAndMortyConstants.Location, RickAndMortyConstants.PageIndexEquals(pageIndex)));
        var content = await httpResponseMessage.Content.ReadAsStringAsync();
        response = JsonSerializer.Deserialize<RickAndMortyApiResponseModel<GetLocationDto>>(content);
        IPagination<GetLocationDto> pagination = await response.results.ToPaginationAsync<GetLocationDto>(pageIndex, pageSize, response.info.count);
        return new SuccessfulContentResponse<IPagination<GetLocationDto>>(pagination, "Listelendi", "Başarılı");
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
