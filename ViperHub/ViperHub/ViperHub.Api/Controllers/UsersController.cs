using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ViperHub.Application.Dto.Users;
using ViperHub.Application.Interfaces;
using ViperHub.Application.Interfaces.Service;
using ViperHub.Application.Services;
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
            await _service.AddAsync(categoryEntity);
            var categoryDto = _mapper.Map<UsuarioResponse>(categoryEntity);
            return Ok(categoryDto);
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
            if (UpdateUser == null)
            {
                return NotFound(UpdateUser);
            }
            return Ok(UpdateUser);
        }

        [HttpGet("{id}/password")]
        public async Task<IActionResult> GetPassword(int id)
        {
            var user = await _service.GetByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(user.Password);
        }


        // Este es un ejemplo de cómo podrías extraer el ID desde el token JWT
        private int GetUserIdFromToken()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userIdClaim = claimsIdentity?.FindFirst(ClaimTypes.NameIdentifier);
            return userIdClaim != null ? int.Parse(userIdClaim.Value) : 0;
        }
    }
}
