using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RickAndMorty.Application.Abstraction.Services;
using RickAndMorty.Application.Dtos.RickAndMortyApi;
using RickAndMorty.Infrastructure.Service;

namespace RickAndMorty.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EpisodesController : ControllerBase
    {
        private readonly IEpisodeService _episodeService;
        //controller ayır metotları tşa
        public EpisodesController(IEpisodeService episodeService)
        {
            _episodeService = episodeService;
        }

        [HttpGet("GetEpisodeById")]
        public async Task<IActionResult> GetEpisodeById(int episodeId) 
        {
            var response =  await _episodeService.GetEpisodeDtoByIdAsync(episodeId);

            if (response.IsSuccess)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }

        [HttpGet("GetEpisodeDetailsById")]
        public async Task<IActionResult> GetCharacterDetailsByIdAsync(int episodeId)
        {
            var response = await _episodeService.GetEpisodeDetailsDtoByIdAsync(episodeId);

            if (response.IsSuccess)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }

        [HttpGet("GetPaginatedEpisodeDtoList")]
        public async Task<IActionResult> GetPaginatedEpisodeDtoListAsync(int pageIndex, int pageSize)
        {
            PaginationRequest paginationRequest = new PaginationRequest();
            paginationRequest.Index = pageIndex;
            paginationRequest.Count = pageSize;

            var response = await _episodeService.GetPaginationEpisodeDtoAsync(pageIndex, pageSize);

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
