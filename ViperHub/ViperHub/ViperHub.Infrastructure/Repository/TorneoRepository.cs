using Microsoft.EntityFrameworkCore;
using ViperHub.Application.Interfaces;
using ViperHub.Domain.Models;
using ViperHub.Infrastructure.Persistence;

namespace ViperHub.Infrastructure.Repository
{
    public class TorneoRepository : ITorneos

    {
        protected readonly ViperHubContext _db;
        public TorneoRepository(ViperHubContext viperHubContext)
        {
            _db=viperHubContext;
        }

        public Task<string> AddAsync(Torneo entity)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Torneo>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Torneo> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
