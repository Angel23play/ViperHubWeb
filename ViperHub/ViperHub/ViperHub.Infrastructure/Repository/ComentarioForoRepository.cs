using ViperHub.Application.Interfaces;
using ViperHub.Domain.Models;
using ViperHub.Infrastructure.Persistence;

namespace ViperHub.Infrastructure.Repository
{
    public class ComentarioForoRepository : IComentariosForo
    {
        protected readonly ViperHubContext _db;
        public ComentarioForoRepository(ViperHubContext viperHubContext)
        {
            _db=viperHubContext;
        }

        public Task<string> AddAsync(ComentariosForo entity)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<ComentariosForo>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ComentariosForo> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
