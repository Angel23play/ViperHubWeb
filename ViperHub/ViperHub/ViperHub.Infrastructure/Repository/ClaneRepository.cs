using ViperHub.Application.Interfaces;
using ViperHub.Domain.Models;
using ViperHub.Infrastructure.Persistence;

namespace ViperHub.Infrastructure.Repository
{
    public class ClaneRepository : IClanes
    {
        protected readonly ViperHubContext _db;
        public ClaneRepository(ViperHubContext viperHubContext)
        {
            _db=viperHubContext;
        }

        public Task<string> AddAsync(Clane entity)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Clane>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Clane> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
