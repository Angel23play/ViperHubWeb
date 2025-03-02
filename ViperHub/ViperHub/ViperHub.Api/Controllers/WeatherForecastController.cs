using Microsoft.AspNetCore.Mvc;
using ViperHub.Application.Foro.Dto;
using ViperHub.Application.Foro.Handles;

namespace ViperHub.Api.Controllerss
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        protected readonly GetAllCategoriaForoHandel services;

        public WeatherForecastController(GetAllCategoriaForoHandel getAllCategoriaForoHandle)
        {
            services = getAllCategoriaForoHandle;
        }

        [HttpGet(Name = "Categoria")]
        public IActionResult GetCategoriaForoAll()
        {
            var result = services.GetAll();
            return Ok(result);
        }

    }
}
