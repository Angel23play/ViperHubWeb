using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ViperHub.Application.Interfaces;
using ViperHub.Domain.Models;
using ViperHub.Infrastructure.Persistence;

namespace ViperHub.Infrastructure.Repository
{
    public class UsuarioRepository : IUsuario
    {
        protected readonly ViperHubContext _db;
        protected readonly IMapper _mapper;
        public UsuarioRepository(ViperHubContext viperHubContext, IMapper mapper)
        {
            _db = viperHubContext;
            _mapper = mapper;
        }

        public async Task<string> AddAsync(Usuario entity)
        {
            _db.Usuarios.Add(entity);
            await _db.SaveChangesAsync();
            return "The category has been created";

        }

        public async Task<string> DeleteAsync(int id)
        {
            var users = await GetByIdAsync(id);

            if (users == null) return "Category not found!";

            _db.Usuarios.Remove(users);

            await _db.SaveChangesAsync();

            return "The category has been deleted";

        }

        public async Task<IReadOnlyList<Usuario>> GetAllAsync()
        {

            return await _db.Usuarios.ToListAsync();
        }

        public async Task<Usuario> GetByIdAsync(int id)
        {
            var users = await _db.Usuarios.FindAsync(id);

            if (users == null)
            {
                throw new KeyNotFoundException($"User with ID {id} not found.");
            }

            return users;



        }



        public async Task<string> UpdateAsync(int id, Usuario entity)
        {
            var users = await GetByIdAsync(id);
            if (users == null)
            {
                return "The User has not updated";

            }


            _mapper.Map(entity, users);

            await _db.SaveChangesAsync();

            return "The User has been updated";
        }
    }
}






