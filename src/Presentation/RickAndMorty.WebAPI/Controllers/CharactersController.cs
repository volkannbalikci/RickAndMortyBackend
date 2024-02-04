using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RickAndMorty.Application.Abstraction.Services;
using RickAndMorty.Application.Dtos.RickAndMortyApi;
using RickAndMorty.Infrastructure.Service;

namespace RickAndMorty.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private readonly ICharacterService _characterService;
        public CharactersController(CharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet("GetCharacterById")]
        public async Task<IActionResult> GetCharacterById(int characterId)
        {
            var response = await _characterService.GetCharacterDtoByIdAsync(characterId);

            if (response.IsSuccess)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }

        [HttpGet("GetCharacterDetailsById")]
        public async Task<IActionResult> GetCharacterDetailsByIdAsync(int characterId)
        {
            var response = await _characterService.GetCharacterDetailsDtoByIdAsync(characterId);

            if (response.IsSuccess)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }

        [HttpGet("GetPaginatedCharacterDtoList")]
        public async Task<IActionResult> GetPaginatedCharacterDtoListAsync(int pageIndex, int pageSize)
        {
            PaginationRequest paginationRequest = new PaginationRequest();
            paginationRequest.Index = pageIndex;
            paginationRequest.Count = pageSize;

            var response = await _characterService.GetPaginationCharacterDtoAsync(pageIndex, pageSize);

            if (response.IsSuccess)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }
    }
}
