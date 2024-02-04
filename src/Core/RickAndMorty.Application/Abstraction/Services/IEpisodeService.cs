using RickAndMorty.Application.Dtos.RickAndMortyApi;
using RickAndMorty.Application.RickAndMortyApi.Dtos;
using RickAndMorty.Application.Utilities.Pagination.Abstractions;
using RickAndMorty.Application.Utilities.Responses.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMorty.Application.Abstraction.Services;

public interface IEpisodeService
{
    Task<IContentResponse<GetEpisodeDto>> GetEpisodeDtoByIdAsync(int episodeId);
    Task<IContentResponse<IPagination<GetEpisodeDto>>> GetPaginationEpisodeDtoAsync(int pageIndex, int pageSize);
    Task<IContentResponse<GetEpisodeDetailsDto>> GetEpisodeDetailsDtoByIdAsync(int episodeId);
}
