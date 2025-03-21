using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ViperHub.Application.Interfaces;
using ViperHub.Domain.Models;
using ViperHub.Infrastructure.Persistence;

namespace ViperHub.Infrastructure.Repository
{
    public class TorneoRepository : ITorneos

    {
        protected readonly ViperHubContext _db;
        protected readonly IMapper _mapper;
        public TorneoRepository(ViperHubContext viperHubContext, IMapper mapper)
        {
            _db=viperHubContext;
            _mapper = mapper;
        }


        public async Task<string> AddAsync(Torneo entity)
        {


            _db.Torneos.Add(entity);
            await _db.SaveChangesAsync();
            return "The category has been created";

        }

        public async Task<string> DeleteAsync(int id)
        {
            var tournament = await GetByIdAsync(id);

            if (tournament == null) return "Category not found!";

            _db.Torneos.Remove(tournament);

            await _db.SaveChangesAsync();

            return "The category has been deleted";

        }


        public async Task<IReadOnlyList<Torneo>> GetAllAsync()
        {
            return await _db.Torneos.ToListAsync();

        }


        public async Task<Torneo> GetByIdAsync(int id)
        {
            var tournament = await _db.Torneos.FindAsync(id);

            if (tournament == null)
            {
                throw new KeyNotFoundException($"Category with ID {id} not found.");
            }

            return tournament;



        }

        public async Task<string> UpdateAsync(int id, Torneo NewEntity)
        {
            var tournament = await GetByIdAsync(id);
            if (tournament == null)
            {
                return "The category has not updated";

            }


            _mapper.Map(NewEntity, tournament);

            await _db.SaveChangesAsync();

            return "The category has been updated";
        }
    }
}

