using RickAndMorty.Application.RickAndMortyApi.Dtos;
using RickAndMorty.Application.Utilities.Pagination.Abstractions;
using RickAndMorty.Application.Utilities.Responses.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMorty.Application.Abstraction.Services
{
    public interface IRickAndMortyService
    {
        Task<IContentResponse<GetLocationDto>> GetLocationDtoByIdAsync(int locationId);
        Task<IContentResponse<IPagination<GetLocationDto>>> GetPaginationLocationDtoAsync(int pageIndex, int pageSize);
        Task<IContentResponse<GetLocationDetailsDto>> GetLocationDetailsDtoByIdAsync(int locationId);

        Task<IContentResponse<GetEpisodeDto>> GetEpisodeDtoByIdAsync(int episodeId);
        Task<IContentResponse<IPagination<GetEpisodeDto>>> GetPaginationEpisodeDtoAsync(int pageIndex, int pageSize);
        Task<IContentResponse<GetEpisodeDetailsDto>> GetEpisodeDetailsDtoByIdAsync(int episodeId);

        Task<IContentResponse<GetCharacterDto>> GetCharacterDtoByIdAsync(int characterId);
        Task<IContentResponse<IPagination<GetCharacterDto>>> GetPaginationCharacterDtoAsync(int pageIndex, int pageSize);
        Task<IContentResponse<GetCharacterDetailsDto>> GetCharacterDetailsDtoByIdAsync(int characterId);

    }
}
