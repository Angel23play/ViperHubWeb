using ViperHub.Application.Interfaces;
using ViperHub.Domain.Models;
using ViperHub.Infrastructure.Persistence;

namespace ViperHub.Infrastructure.Repository
{
    public class MultimediumRepository : IMultimedium
    {
        protected readonly ViperHubContext _db;
        public MultimediumRepository(ViperHubContext viperHubContext)
        {
            _db=viperHubContext;
        }

        public Task<string> AddAsync(Multimedium entity)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Multimedium>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Multimedium> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
