using RickAndMorty.Application.Abstraction.Services;
using RickAndMorty.Application.Utilities.Responses.Common;
using RickAndMorty.Application.Utilities.Responses.ContentResponse;
using RickAndMorty.Infrastructure.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using RickAndMorty.Application.RickAndMortyApi.Dtos;
using RickAndMorty.Application.Dtos.RickAndMortyApi;
using RickAndMorty.Application.RickAndMortyApi.Models;
using System.Reflection.Metadata;
using RickAndMorty.Application.Utilities.Pagination.Abstractions;
using RickAndMorty.Application.Utilities.Pagination.Extensions;
using RickAndMorty.Application.Utilities.Pagination.Implementations;

namespace RickAndMorty.Infrastructure.Services
{
    public class EpisodeService : IEpisodeService
    {
        private readonly HttpClient _httpClient;
        private readonly ICharacterService _characterService;

        public EpisodeService(HttpClient httpClient, ICharacterService characterService)
        {
            _httpClient = httpClient;
            _characterService = characterService;
        }

        public async Task<IContentResponse<GetEpisodeDto>> GetEpisodeDtoByIdAsync(int episodeId)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync(this.GetAlignedUrl(RickAndMortyConstants.RickAndMortyBaseApiUrlString, RickAndMortyConstants.Episode, episodeId.ToString()));
            var content = await httpResponseMessage.Content.ReadAsStringAsync();
            GetEpisodeDto getEpisodeDto = JsonSerializer.Deserialize<GetEpisodeDto>(content);
            return new SuccessfulContentResponse<GetEpisodeDto>(getEpisodeDto, "Listelendi", "Başarılı");
        }

        public async Task<IContentResponse<GetEpisodeDetailsDto>> GetEpisodeDetailsDtoByIdAsync(int episodeId)
        {
            GetEpisodeDetailsDto getEpisodeDetailsDto = new GetEpisodeDetailsDto();
            var response = await this.GetEpisodeDtoByIdAsync(episodeId);
            GetEpisodeDto episodeDto = response.Data;

            getEpisodeDetailsDto.id = episodeDto.id;
            getEpisodeDetailsDto.name = episodeDto.name;
            getEpisodeDetailsDto.air_date = episodeDto.air_date;
            getEpisodeDetailsDto.episode = episodeDto.episode;
            getEpisodeDetailsDto.url = episodeDto.url;
            getEpisodeDetailsDto.created = episodeDto.created;

            List<GetCharacterDto> getCharacterDtoList = new List<GetCharacterDto>();
            foreach (var characterId in episodeDto.characterIdList)
            {
                var characterResponse = await _characterService.GetCharacterDtoByIdAsync(Convert.ToInt32(episodeId));
                GetCharacterDto getCharacterDto = characterResponse.Data;
                getCharacterDtoList.Add(getCharacterDto);
            }
            getEpisodeDetailsDto.characterDetailsDtoList = getCharacterDtoList;   
            
            return new SuccessfulContentResponse<GetEpisodeDetailsDto>(getEpisodeDetailsDto, "Listelendi", "Başarılı"); ;
        }

        public async Task<IContentResponse<IPagination<GetEpisodeDto>>> GetPaginationEpisodeDtoAsync(int pageIndex, int pageSize)
        {
            RickAndMortyApiResponseModel<GetEpisodeDto> response = new RickAndMortyApiResponseModel<GetEpisodeDto>();
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync(this.GetAlignedUrl(RickAndMortyConstants.RickAndMortyBaseApiUrlString, RickAndMortyConstants.Episode, RickAndMortyConstants.PageIndexEquals(pageIndex)));
            var content = await httpResponseMessage.Content.ReadAsStringAsync();
            response = JsonSerializer.Deserialize<RickAndMortyApiResponseModel<GetEpisodeDto>>(content);
            IPagination<GetEpisodeDto> pagination = await response.results.ToPaginationAsync<GetEpisodeDto>(pageIndex, pageSize, response.info.count);
            return new SuccessfulContentResponse<IPagination<GetEpisodeDto>>(pagination, "Listelendi", "Başarılı");
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
}
