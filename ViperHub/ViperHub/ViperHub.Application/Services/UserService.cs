using AutoMapper;
using ViperHub.Application.Interfaces.Service;
using ViperHub.Domain.Models;
using ViperHub.Infrastructure.RepoInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ViperHub.Application.Services
{
    public class UserService : IUsuarioContract
    {
        protected readonly IUsuario _repository;
        protected readonly IMapper _mapper;

        public UserService(IUsuario repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper ;
        }

        // Metodo para agregar un usuario
        public async Task<string> AddAsync(Usuario entity)
        {
            try
            {
                var result = await _repository.AddAsync(entity);
                
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el usuario: " + ex.Message);
            }
            
            return "";
            
        }

        // M�todo para eliminar un usuario
        public async Task<string> DeleteAsync(int id)
        {
            try
            {
                var result = await _repository.DeleteAsync(id);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el usuario: " + ex.Message);
            }
        }

        // M�todo para obtener todos los usuarios
        public async Task<IReadOnlyList<Usuario>> GetAllAsync()
        {
            try
            {
                return await _repository.GetAllAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los usuarios: " + ex.Message);
            }
        }

        // M�todo para obtener un usuario por ID
        public async Task<Usuario> GetByIdAsync(int id)
        {
            try
            {
                return await _repository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el usuario: " + ex.Message);
            }
        }

        // M�todo para actualizar un usuario
        public async Task<string> UpdateAsync(int id, Usuario entity)
        {
            try
            {
                var result = await _repository.UpdateAsync(id, entity);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el usuario: " + ex.Message);
            }
        }

        // M�todo para verificar la contrasena de un usuario
        public async Task<bool> VerifyPassword(Usuario user, string password)
        {
            
            return user.Password == password;  
        }

        // M�todo para cambiar la contrasenaa de un usuario
        public async Task<string> ChangePassword(Usuario user, string newPassword)
        {
            try
            {
                // Verificaci�n de la nueva contrasena (puedes implementar validaciones adicionales si es necesario)
                if (newPassword.Length < 6) 
                {
                    throw new Exception("La nueva contrasena es demasiado corta.");
                }

                user.Password = newPassword; // Cambiar la contrasena directamente
                await _repository.UpdateAsync(user.Id, user);

                return "Contrasena cambiada exitosamente.";
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cambiar la contrasena: " + ex.Message);
            }
        }
    }
}
