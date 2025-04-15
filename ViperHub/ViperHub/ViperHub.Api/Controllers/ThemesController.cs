using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ViperHub.Application.Dto.Themes;

using ViperHub.Application.Interfaces;
using ViperHub.Domain.Models;
using ViperHub.Infrastructure.RepoInterfaces;

namespace ViperHub.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ThemesController : ControllerBase
    {
        protected readonly ITemasForo _repository;
        protected readonly IMapper _mapper;

        public ThemesController(ITemasForo temasForo, IMapper mapper)
        {
            _mapper = mapper;
            _repository = temasForo;
            
        }

        [HttpGet(Name = "Temas")]
        public async Task<IActionResult> GetTeamsAll()
        {
            var result = await _repository.GetAllAsync();

            var returnAllCategorys = _mapper.Map<List<TemasForoResponse>>(result);

            return Ok(returnAllCategorys);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetThemes(int id)
        {


            var team = await _repository.GetByIdAsync(id);
            if (team == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<TemasForoResponse>(team));
        }

        [HttpPost]
        public async Task<IActionResult> AddThemes([FromBody]TemasForoDto NewTeam)
        {


            var ThemeEntity = _mapper.Map<TemasForo>(NewTeam);

            // Guardando la entidad en la base de datos
            await _repository.AddAsync(ThemeEntity);

            // Mapeando la entidad guardada nuevamente a DTO para devolver la respuesta
            var TeamDto = _mapper.Map<TemasForoResponse>(ThemeEntity);

            return Ok(TeamDto); // Retornamos el DTO mapeado
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTheme(int id)
        {
            var team = await _repository.GetByIdAsync(id);
            if (team == null)
            {
                return NotFound($"Category with ID {id} not found.");
            }

            await _repository.DeleteAsync(id);

            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTheme(int id, TemasForoDto category)
        {
            var UpdateCategory = _mapper.Map<TemasForo>(category);

            await _repository.UpdateAsync(id, UpdateCategory);
            if (_repository == null)
            {
                return NotFound(UpdateCategory);
            }


            return Ok(UpdateCategory);
        }

    }
}
