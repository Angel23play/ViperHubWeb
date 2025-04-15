using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ViperHub.Application.Dto.Tournaments;
using ViperHub.Application.Interfaces;
using ViperHub.Application.Interfaces.Service;
using ViperHub.Domain.Models;

namespace ViperHub.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TournamentsController : ControllerBase
    {
        protected readonly ITorneosContract _repository;
        protected readonly IMapper _mapper;

        public TournamentsController(ITorneosContract repository, IMapper mapper)
        {

            _repository = repository;
            _mapper = mapper;
        }


        [HttpGet(Name = "Torneos")]
        public async Task<IActionResult> GetTournamentsAll()
        {
            var result = await _repository.GetAllAsync();

            var returnAllCategorys = _mapper.Map<List<TorneoResponse>>(result);

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

            return Ok(_mapper.Map<TorneoResponse>(tournament));
        }

        [HttpPost]
        public async Task<IActionResult> AddTournament(TorneoDto NewTournament)
        {


            var tournamentEntity = _mapper.Map<Torneo>(NewTournament);

            // Guardando la entidad en la base de datos
            await _repository.AddAsync(tournamentEntity);

            // Mapeando la entidad guardada nuevamente a DTO para devolver la respuesta
            var tournamentsDto = _mapper.Map<TorneoDto>(tournamentEntity);

            return Ok(tournamentsDto); // Retornamos el DTO mapeado
        }

        [HttpDelete("{id}")]
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
        [HttpPut("{id}")]
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

