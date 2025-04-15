using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ViperHub.Application.Dto.ClanMembers;
using ViperHub.Application.Interfaces;
using ViperHub.Domain.Models;
using ViperHub.Infrastructure.RepoInterfaces;

namespace ViperHub.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MembersClanController : ControllerBase
    {
        
        protected readonly IUsuariosClan _repository;
        protected readonly IMapper _mapper;

        public MembersClanController(IUsuariosClan repository, IMapper mapper)
        {

            _repository = repository;
            _mapper = mapper;
        }


        [HttpGet(Name = "Miembros")]
        public async Task<IActionResult> GetMembersAll()
        {
            var result = await _repository.GetAllAsync();

            var returnAllMembers = _mapper.Map<List<UsuariosClanesResponse>>(result);

            return Ok(returnAllMembers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMember(int id)
        {


            var member = await _repository.GetByIdAsync(id);
            if (member == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<UsuariosClanesResponse>(member));
        }

        [HttpPost]
        public async Task<IActionResult> AddMember(UsuariosClanesDto NewCategory)
        {


            var MemberEntity = _mapper.Map<UsuarioClane>(NewCategory);

            // Guardando la entidad en la base de datos
            await _repository.AddAsync(MemberEntity);

            // Mapeando la entidad guardada nuevamente a DTO para devolver la respuesta
            var MemberDto = _mapper.Map<UsuariosClanesResponse>(MemberEntity);

            return Ok(MemberDto); // Retornamos el DTO mapeado
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMember(int id)
        {
            var Member = await _repository.GetByIdAsync(id);
            if (Member == null)
            {
                return NotFound($"Member with ID {id} not found.");
            }

            await _repository.DeleteAsync(id);

            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMember(int id, UsuariosClanesDto member)
        {
            var UpdateMember = _mapper.Map<UsuarioClane>(member);

            await _repository.UpdateAsync(id, UpdateMember);
            if (_repository == null)
            {
                return NotFound(UpdateMember);
            }


            return Ok(UpdateMember);
        }
        
    }

}