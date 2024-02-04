using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RickAndMorty.Application.Abstraction.Services;
using RickAndMorty.Application.Dtos.RickAndMortyApi;
using RickAndMorty.Infrastructure.Services;
using RickAndMorty.WebAPI.Controllers.Common;

namespace RickAndMorty.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RickAndMortyController : CustomControllerBase
    {
        public RickAndMortyController(IRickAndMortyService rickAndMortyService) : base(rickAndMortyService)
        {
        }

        [HttpGet("GetCharacterById")]
        public async Task<IActionResult> GetCharacterById(int characterId)
        {
            var response = await _rickAndMortyService.GetCharacterDtoByIdAsync(characterId);

            return base.ActionResultInstanceByResponse(response);
        }

        [HttpGet("GetCharacterDetailsById")]
        public async Task<IActionResult> GetCharacterDetailsByIdAsync(int characterId)
        {
            var response = await _rickAndMortyService.GetCharacterDetailsDtoByIdAsync(characterId);

            return base.ActionResultInstanceByResponse(response);
        }

        [HttpGet("GetPaginatedCharacterDtoList")]
        public async Task<IActionResult> GetPaginatedCharacterDtoListAsync(int pageIndex, int pageSize)
        {
            PaginationRequest paginationRequest = new PaginationRequest();
            paginationRequest.Index = pageIndex;
            paginationRequest.Count = pageSize;

            var response = await _rickAndMortyService.GetPaginationCharacterDtoAsync(pageIndex, pageSize);

            return base.ActionResultInstanceByResponse(response);
        }

        [HttpGet("GetEpisodeById")]
        public async Task<IActionResult> GetEpisodeById(int episodeId)
        {
            var response = await _rickAndMortyService.GetEpisodeDtoByIdAsync(episodeId);

            return base.ActionResultInstanceByResponse(response);
        }

        [HttpGet("GetEpisodeDetailsById")]
        public async Task<IActionResult> GetEpisodeDetailsByIdAsync(int episodeId)
        {
            var response = await _rickAndMortyService.GetEpisodeDetailsDtoByIdAsync(episodeId);

            return base.ActionResultInstanceByResponse(response);
        }

        [HttpGet("GetPaginatedEpisodeDtoList")]
        public async Task<IActionResult> GetPaginatedEpisodeDtoListAsync(int pageIndex, int pageSize)
        {
            PaginationRequest paginationRequest = new PaginationRequest();
            paginationRequest.Index = pageIndex;
            paginationRequest.Count = pageSize;

            var response = await _rickAndMortyService.GetPaginationEpisodeDtoAsync(pageIndex, pageSize);

            return base.ActionResultInstanceByResponse(response);
        }

        [HttpGet("GetPaginatedLocationDtoList")]
        public async Task<IActionResult> GetPaginatedLocationDtoListAsync(int pageIndex, int pageSize)
        {
            PaginationRequest paginationRequest = new PaginationRequest();
            paginationRequest.Index = pageIndex;
            paginationRequest.Count = pageSize;

            var response = await _rickAndMortyService.GetPaginationLocationDtoAsync(pageIndex, pageSize);

            return base.ActionResultInstanceByResponse(response);
        }

        [HttpGet("GetLocationById")]
        public async Task<IActionResult> GetLocationById(int locationId)
        {
            var response = await _rickAndMortyService.GetLocationDtoByIdAsync(locationId);

            return base.ActionResultInstanceByResponse(response);
        }

        [HttpGet("GetLocationDetailsById")]
        public async Task<IActionResult> GetLocationDetailsByIdAsync(int locationId)
        {
            var response = await _rickAndMortyService.GetLocationDetailsDtoByIdAsync(locationId);

            return base.ActionResultInstanceByResponse(response);
        }
    }
}
