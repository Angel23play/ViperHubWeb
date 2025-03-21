using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ViperHub.Application.Foro.Dto.Teams;
using ViperHub.Application.Interfaces;
using ViperHub.Domain.Models;

namespace ViperHub.Api.Controllers
{
        [ApiController]
        [Route("api/[controller]")]
    public class TeamsController : ControllerBase
    {
        



            protected readonly IEquiposTorneos _repository;
            protected readonly IMapper _mapper;

            public TeamsController(IEquiposTorneos repository, IMapper mapper)
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
            public async Task<IActionResult> GetTeams(int id)
            {


                var team = await _repository.GetByIdAsync(id);
                if (team == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<EquiposTorneoResponse>(team));
            }

            [HttpPost]
            public async Task<IActionResult> AddTeams(EquiposTorneoDto NewTeam)
            {


                var TeamEntity = _mapper.Map<EquiposTorneo>(NewTeam);

                // Guardando la entidad en la base de datos
                await _repository.AddAsync(TeamEntity);

                // Mapeando la entidad guardada nuevamente a DTO para devolver la respuesta
                var TeamDto = _mapper.Map<EquiposTorneoResponse>(TeamEntity);

                return Ok(TeamDto); // Retornamos el DTO mapeado
            }

            [HttpDelete]
            public async Task<IActionResult> DeleteCategory(int id)
            {
                var team = await _repository.GetByIdAsync(id);
                if (team == null)
                {
                    return NotFound($"Category with ID {id} not found.");
                }

                await _repository.DeleteAsync(id);

                return NoContent();
            }
            [HttpPut]
            public async Task<IActionResult> UpdateCategory(int id, EquiposTorneoDto category)
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


