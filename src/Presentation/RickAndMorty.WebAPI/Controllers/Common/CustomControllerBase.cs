using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RickAndMorty.Application.Abstraction.Services;
using RickAndMorty.Application.Utilities.Responses.Common;

namespace RickAndMorty.WebAPI.Controllers.Common
{
    public class CustomControllerBase : ControllerBase
    {
        protected readonly IRickAndMortyService _rickAndMortyService;

        public CustomControllerBase(IRickAndMortyService rickAndMortyService)
        {
            _rickAndMortyService = rickAndMortyService;
        }

        protected IActionResult ActionResultInstanceByResponse(IResponse response)
        {
            if (response.IsSuccess is true)
                return Ok(response);
            else
                return BadRequest($"{response.Title}:{response.Message}");
        }
    }
}
