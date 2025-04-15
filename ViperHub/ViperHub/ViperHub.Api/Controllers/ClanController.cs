using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ViperHub.Application.Dto.Clans;
using ViperHub.Application.Interfaces;
using ViperHub.Application.Interfaces.Service;
using ViperHub.Domain.Models;

namespace ViperHub.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClanController : ControllerBase
    {
        
        protected readonly IClanesContract _repository;
        protected readonly IMapper _mapper;

        public ClanController(IClanesContract repository, IMapper mapper)
        {

            _repository = repository;
            _mapper = mapper;
        }


        [HttpGet(Name = "Clanes")]
        public async Task<IActionResult> GetClanesAll()
        {
            var result = await _repository.GetAllAsync();

            var returnAllCategorys = _mapper.Map<List<ClanesResponse>>(result);

            return Ok(returnAllCategorys);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClan(int id)
        {


            var clan = await _repository.GetByIdAsync(id);
            if (clan == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ClanesResponse>(clan));
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(ClanesDto NewClan)
        {


            var clan = _mapper.Map<Clane>(NewClan);

            // Guardando la entidad en la base de datos
            await _repository.AddAsync(clan);

            // Mapeando la entidad guardada nuevamente a DTO para devolver la respuesta
            var clanDto = _mapper.Map<ClanesDto>(NewClan);

            return Ok(clanDto); // Retornamos el DTO mapeado
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClan(int id)
        {
            var Clan = await _repository.GetByIdAsync(id);
            if (Clan == null)
            {
                return NotFound($"Category with ID {id} not found.");
            }

            await _repository.DeleteAsync(id);

            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCLan(int id, ClanesDto entity)
        {
            var UpdateClan = _mapper.Map<Clane>(entity);

            await _repository.UpdateAsync(id, UpdateClan);
            if (_repository == null)
            {
                return NotFound(UpdateClan);
            }


            return Ok(UpdateClan);
        }
         
    }

}

