using ViperHub.Application.Interfaces;
using ViperHub.Domain.Models;
using ViperHub.Infrastructure.Persistence;

namespace ViperHub.Infrastructure.Repository
{
    public class UsuarioClaneRepository : IUsuariosClan
    {
        protected readonly ViperHubContext _db;
        public UsuarioClaneRepository(ViperHubContext viperHubContext)
        {
            _db = viperHubContext;
        }

        public Task<string> AddAsync(UsuarioClane entity)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<UsuarioClane>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioClane> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
