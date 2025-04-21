using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ViperHub.Application.Dtos.Login;
using ViperHub.Application.Interfaces.Service;
using ViperHub.Domain.Models;

namespace ViperHub.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUsuarioContract _userService;
        private readonly IConfiguration _config;

        public AuthController(IUsuarioContract userService, IConfiguration config)
        {
            _userService = userService;
            _config = config;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Login dto)
        {
            // Buscar usuario por username y contraseña
            var usuarios = await _userService.GetAllAsync();
            var user = usuarios.FirstOrDefault(u =>
                u.Username == dto.Username && u.Password == dto.Password);

            if (user == null)
                return Unauthorized("Usuario o contraseña incorrectos.");

            // Crear JWT con el ID del usuario
            var claims = new[]
            {
                new Claim("userId", user.Id.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds
            );

            // Respuesta esperada por el frontend
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                id = user.Id // ← nombre cambiado de 'userId' a 'id'
            });
        }
    }
}
