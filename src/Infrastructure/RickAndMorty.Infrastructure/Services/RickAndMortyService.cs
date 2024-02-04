using RickAndMorty.Application.Abstraction.Services;
using RickAndMorty.Application.RickAndMortyApi.Dtos;
using RickAndMorty.Application.RickAndMortyApi.Models;
using RickAndMorty.Application.Utilities.Pagination.Abstractions;
using RickAndMorty.Application.Utilities.Responses.Common;
using RickAndMorty.Application.Utilities.Responses.ContentResponse;
using RickAndMorty.Application.Utilities.Pagination.Abstractions;
using RickAndMorty.Application.Utilities.Pagination.Extensions;
using RickAndMorty.Application.Utilities.Pagination.Implementations;
using RickAndMorty.Infrastructure.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RickAndMorty.Infrastructure.Services
{
    public class RickAndMortyService : IRickAndMortyService
    {
        private readonly HttpClient _httpClient;

        public RickAndMortyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
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
                var episodeResponse = await this.GetEpisodeDtoByIdAsync(Convert.ToInt32(episodeId));
                GetEpisodeDto getEpisodeDto = episodeResponse.Data;
                getEpisodeDtoList.Add(getEpisodeDto);
            }
            getCharacterDetailsDto.episode = getEpisodeDtoList;

            var originResponse = await this.GetLocationDtoByIdAsync(Convert.ToInt32(characterDto.originId));
            GetLocationDto origin = originResponse.Data;
            getCharacterDetailsDto.origin = origin;

            var locationResponse = await this.GetLocationDtoByIdAsync(Convert.ToInt32(characterDto.locationId));
            GetLocationDto location = locationResponse.Data;
            getCharacterDetailsDto.location = location;

            return new SuccessfulContentResponse<GetCharacterDetailsDto>(getCharacterDetailsDto, RickAndMortyConstants.CharactersListedMessage, RickAndMortyConstants.SuccessfulTitle);
        }

        public async Task<IContentResponse<GetCharacterDto>> GetCharacterDtoByIdAsync(int characterId)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync(this.GetAlignedUrl(RickAndMortyConstants.RickAndMortyBaseApiUrlString, RickAndMortyConstants.Character, characterId.ToString()));
            var content = await httpResponseMessage.Content.ReadAsStringAsync();
            GetCharacterDto getCharacterDto = JsonSerializer.Deserialize<GetCharacterDto>(content);
            return new SuccessfulContentResponse<GetCharacterDto>(getCharacterDto, RickAndMortyConstants.CharactersListedMessage, RickAndMortyConstants.SuccessfulTitle);
        }

        public async Task<IContentResponse<GetEpisodeDto>> GetEpisodeDtoByIdAsync(int episodeId)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync(this.GetAlignedUrl(RickAndMortyConstants.RickAndMortyBaseApiUrlString, RickAndMortyConstants.Episode, episodeId.ToString()));
            var content = await httpResponseMessage.Content.ReadAsStringAsync();
            GetEpisodeDto getEpisodeDto = JsonSerializer.Deserialize<GetEpisodeDto>(content);
            return new SuccessfulContentResponse<GetEpisodeDto>(getEpisodeDto, RickAndMortyConstants.EpisodesListedMessage, RickAndMortyConstants.SuccessfulTitle);
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
                var characterResponse = await this.GetCharacterDtoByIdAsync(Convert.ToInt32(characterId));
                GetCharacterDto getCharacterDto = characterResponse.Data;
                getCharacterDtoList.Add(getCharacterDto);
            }
            getEpisodeDetailsDto.characterDetailsDtoList = getCharacterDtoList;

            return new SuccessfulContentResponse<GetEpisodeDetailsDto>(getEpisodeDetailsDto, RickAndMortyConstants.EpisodesListedMessage, RickAndMortyConstants.SuccessfulTitle); ;
        }

        public async Task<IContentResponse<IPagination<GetEpisodeDto>>> GetPaginationEpisodeDtoAsync(int pageIndex, int pageSize)
        {
            RickAndMortyApiResponseModel<GetEpisodeDto> response = new RickAndMortyApiResponseModel<GetEpisodeDto>();
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync(this.GetAlignedUrl(RickAndMortyConstants.RickAndMortyBaseApiUrlString, RickAndMortyConstants.Episode, RickAndMortyConstants.PageIndexEquals(pageIndex)));
            var content = await httpResponseMessage.Content.ReadAsStringAsync();
            response = JsonSerializer.Deserialize<RickAndMortyApiResponseModel<GetEpisodeDto>>(content);
            IPagination<GetEpisodeDto> pagination = await response.results.ToPaginationAsync<GetEpisodeDto>(pageIndex, pageSize, response.info.count);
            return new SuccessfulContentResponse<IPagination<GetEpisodeDto>>(pagination, RickAndMortyConstants.EpisodesListedMessage, RickAndMortyConstants.SuccessfulTitle);
        }

        public async Task<IContentResponse<GetLocationDto>> GetLocationDtoByIdAsync(int locationId)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync(this.GetAlignedUrl(RickAndMortyConstants.RickAndMortyBaseApiUrlString, RickAndMortyConstants.Location, locationId.ToString()));
            var content = await httpResponseMessage.Content.ReadAsStringAsync();
            GetLocationDto getLocationDto = JsonSerializer.Deserialize<GetLocationDto>(content);
            return new SuccessfulContentResponse<GetLocationDto>(getLocationDto, RickAndMortyConstants.LocationsListedMessage, RickAndMortyConstants.SuccessfulTitle);
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
            foreach (var residentId in locationDto.residentIdList)
            {
                var characterResponse = await this.GetCharacterDtoByIdAsync(Convert.ToInt32(residentId));
                GetCharacterDto getCharacterDto = characterResponse.Data;
                getCharacterDtoList.Add(getCharacterDto);
            }
            getLocationDetailsDto.residents = getCharacterDtoList;

            return new SuccessfulContentResponse<GetLocationDetailsDto>(getLocationDetailsDto, RickAndMortyConstants.LocationsListedMessage, RickAndMortyConstants.SuccessfulTitle); ;
        }

        public async Task<IContentResponse<IPagination<GetLocationDto>>> GetPaginationLocationDtoAsync(int pageIndex, int pageSize)
        {
            RickAndMortyApiResponseModel<GetLocationDto> response = new RickAndMortyApiResponseModel<GetLocationDto>();
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync(this.GetAlignedUrl(RickAndMortyConstants.RickAndMortyBaseApiUrlString, RickAndMortyConstants.Location, RickAndMortyConstants.PageIndexEquals(pageIndex)));
            var content = await httpResponseMessage.Content.ReadAsStringAsync();
            response = JsonSerializer.Deserialize<RickAndMortyApiResponseModel<GetLocationDto>>(content);
            IPagination<GetLocationDto> pagination = await response.results.ToPaginationAsync<GetLocationDto>(pageIndex, pageSize, response.info.count);
            return new SuccessfulContentResponse<IPagination<GetLocationDto>>(pagination, RickAndMortyConstants.LocationsListedMessage, RickAndMortyConstants.SuccessfulTitle);
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
