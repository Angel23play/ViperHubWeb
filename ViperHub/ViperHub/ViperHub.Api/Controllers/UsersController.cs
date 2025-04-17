using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ViperHub.Application.Dto.Users;
using ViperHub.Application.Interfaces;
using ViperHub.Application.Interfaces.Service;
using ViperHub.Domain.Models;

namespace ViperHub.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        protected readonly IUsuarioContract _service;
        protected readonly IMapper _mapper;

        public UsersController(IUsuarioContract service, IMapper mapper)
        {

            _service = service;
            _mapper = mapper;
        }


        [HttpGet(Name = "Usuarios")]
        public async Task<IActionResult> GetUsersAll()
        {
            var result = await _service.GetAllAsync();

            var returnAllCategorys = _mapper.Map<List<UsuarioResponse>>(result);

            return Ok(returnAllCategorys);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsuario(int id)
        {


            var category = await _service.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<UsuarioResponse>(category));
        }

        [HttpPost]
        public async Task<IActionResult> AddUsuario(UsuarioDto NewCategory)
        {


            var categoryEntity = _mapper.Map<Usuario>(NewCategory);

            // Guardando la entidad en la base de datos
            await _service.AddAsync(categoryEntity);

            // Mapeando la entidad guardada nuevamente a DTO para devolver la respuesta
            var categoryDto = _mapper.Map<UsuarioDto>(categoryEntity);

            return Ok(categoryDto); // Retornamos el DTO mapeado
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletetUsuario(int id)
        {
            var Category = await _service.GetByIdAsync(id);
            if (Category == null)
            {
                return NotFound($"Category with ID {id} not found.");
            }

            await _service.DeleteAsync(id);

            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatetUser(int id, UsuarioDto user)
        {
            
            var UpdateUser = _mapper.Map<Usuario>(user);

            await _service.UpdateAsync(id, UpdateUser);
            if (_service == null)
            {
                return NotFound(UpdateUser);
            }


            return Ok(UpdateUser);
        }
    }
}
    