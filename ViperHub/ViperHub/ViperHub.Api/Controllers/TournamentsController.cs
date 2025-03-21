using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ViperHub.Application.Foro.Dto.Tournaments;
using ViperHub.Application.Interfaces;
using ViperHub.Domain.Models;

namespace ViperHub.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TournamentsController : ControllerBase
    {




        protected readonly ITorneos _repository;
        protected readonly IMapper _mapper;

        public TournamentsController(ITorneos repository, IMapper mapper)
        {

            _repository = repository;
            _mapper = mapper;
        }


        [HttpGet(Name = "Torneos")]
        public async Task<IActionResult> GetCategoriaForoAll()
        {
            var result = await _repository.GetAllAsync();

            var returnAllCategorys = _mapper.Map<List<TorneoDto>>(result);

            return Ok(returnAllCategorys);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTournament(int id)
        {


            var tournament = await _repository.GetByIdAsync(id);
            if (tournament == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<TorneoDto>(tournament));
        }

        [HttpPost]
        public async Task<IActionResult> AddTournament(TorneoDto NewTournament)
        {


            var tournamentEntity = _mapper.Map<Torneo>(NewTournament);

            // Guardando la entidad en la base de datos
            await _repository.AddAsync(tournamentEntity);

            // Mapeando la entidad guardada nuevamente a DTO para devolver la respuesta
            var categoryDto = _mapper.Map<TorneoDto>(tournamentEntity);

            return Ok(categoryDto); // Retornamos el DTO mapeado
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTournament(int id)
        {
            var tournament = await _repository.GetByIdAsync(id);
            if (tournament == null)
            {
                return NotFound($"Tournament with ID {id} not found.");
            }

            await _repository.DeleteAsync(id);

            return NoContent();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateTournament(int id, TorneoDto category)
        {
            var UpdateTournament = _mapper.Map<Torneo>(category);

            await _repository.UpdateAsync(id, UpdateTournament);
            if (_repository == null)
            {
                return NotFound(UpdateTournament);
            }


            return Ok(UpdateTournament);
        }
    }
}

