using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RickAndMorty.Application.Abstraction.Services;
using RickAndMorty.Application.Dtos.RickAndMortyApi;
using RickAndMorty.Infrastructure.Service;
using RickAndMorty.Infrastructure.Services;

namespace RickAndMorty.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly ILocationService _locationService;

        public LocationsController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet("GetPaginatedLocationDtoList")]
        public async Task<IActionResult> GetPaginatedLocationDtoListAsync(int pageIndex, int pageSize)
        {
            PaginationRequest paginationRequest = new PaginationRequest();
            paginationRequest.Index = pageIndex;
            paginationRequest.Count = pageSize;

            var response = await _locationService.GetPaginationLocationDtoAsync(pageIndex, pageSize);

            if (response.IsSuccess)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }

        [HttpGet("GetLocationById")]
        public async Task<IActionResult> GetLocationById(int locationId)
        {
            var response = await _locationService.GetLocationDtoByIdAsync(locationId);

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
        public async Task<IActionResult> GetLocationDetailsByIdAsync(int locationId)
        {
            var response = await _locationService.GetLocationDetailsDtoByIdAsync(locationId);

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
