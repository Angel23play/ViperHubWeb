using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ViperHub.Application.Dto.Teams;
using ViperHub.Application.Interfaces;
using ViperHub.Application.Interfaces.Service;
using ViperHub.Domain.Models;

namespace ViperHub.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamsController : ControllerBase
    {

        protected readonly IEquiposTorneosContract _repository;
        protected readonly IMapper _mapper;

        public TeamsController(IEquiposTorneosContract repository, IMapper mapper)
        {

            _repository = repository;
            _mapper = mapper;
        }


        [HttpGet(Name = "Equipos")]
        public async Task<IActionResult> GetTeamsAll()
        {
            var result = await _repository.GetAllAsync();

            var returnAllCategorys = _mapper.Map<List<EquiposTorneoResponse>>(result);

            return Ok(returnAllCategorys);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeam(int id)
        {


            var team = await _repository.GetByIdAsync(id);
            if (team == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<EquiposTorneoResponse>(team));
        }

        [HttpPost]
        public async Task<IActionResult> AddTeam(EquiposTorneoDto NewTeam)
        {


            var TeamEntity = _mapper.Map<EquiposTorneo>(NewTeam);

            // Guardando la entidad en la base de datos
            await _repository.AddAsync(TeamEntity);

            // Mapeando la entidad guardada nuevamente a DTO para devolver la respuesta
            var TeamDto = _mapper.Map<EquiposTorneoResponse>(TeamEntity);

            return Ok(TeamDto); // Retornamos el DTO mapeado
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeam(int id)
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
        public async Task<IActionResult> UpdateTeam(int id, EquiposTorneoDto category)
        {
            var UpdateCategory = _mapper.Map<EquiposTorneo>(category);

            await _repository.UpdateAsync(id, UpdateCategory);
            if (_repository == null)
            {
                return NotFound(UpdateCategory);
            }


            return Ok(UpdateCategory);
        }
    }

}


