using RickAndMorty.Application.RickAndMortyApi.Dtos;
using RickAndMorty.Application.Utilities.Pagination.Abstractions;
using RickAndMorty.Application.Utilities.Responses.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMorty.Application.Abstraction.Services;

public interface ILocationService
{
    Task<IContentResponse<GetLocationDto>> GetLocationDtoByIdAsync(int locationId);
    Task<IContentResponse<IPagination<GetLocationDto>>> GetPaginationLocationDtoAsync(int pageIndex, int pageSize);
    Task<IContentResponse<GetLocationDetailsDto>> GetLocationDetailsDtoByIdAsync(int locationId);
}
