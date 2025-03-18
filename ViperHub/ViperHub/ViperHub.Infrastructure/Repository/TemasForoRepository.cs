using ViperHub.Application.Interfaces;
using ViperHub.Domain.Models;
using ViperHub.Infrastructure.Persistence;

namespace ViperHub.Infrastructure.Repository
{
    public class TemasForoRepository : ITemasForo
    {
        protected readonly ViperHubContext _db;
        public TemasForoRepository(ViperHubContext viperHubContext)
        {
            _db=viperHubContext;
        }

        public Task<string> AddAsync(TemasForo entity)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<TemasForo>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TemasForo> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
