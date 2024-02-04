using RickAndMorty.Application.RickAndMortyApi.Dtos;
using RickAndMorty.Application.Utilities.Pagination.Abstractions;
using RickAndMorty.Application.Utilities.Responses.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMorty.Application.Abstraction.Services;

public interface ICharacterService
{
    Task<IContentResponse<GetCharacterDto>> GetCharacterDtoByIdAsync(int characterId);
    Task<IContentResponse<IPagination<GetCharacterDto>>> GetPaginationCharacterDtoAsync(int pageIndex, int pageSize);
    Task<IContentResponse<GetCharacterDetailsDto>> GetCharacterDetailsDtoByIdAsync(int characterId);
}
