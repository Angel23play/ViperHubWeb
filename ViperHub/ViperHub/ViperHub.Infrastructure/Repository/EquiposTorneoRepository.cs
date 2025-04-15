using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ViperHub.Domain.Models;
using ViperHub.Infrastructure.Persistence;
using ViperHub.Infrastructure.RepoInterfaces;

namespace ViperHub.Infrastructure.Repository
{
    public class EquiposTorneoRepository : IEquiposTorneos
    {
        protected readonly ViperHubContext _db;
        protected readonly IMapper _mapper;
        public EquiposTorneoRepository(ViperHubContext viperHubContext, IMapper mapper)
        {
            _db = viperHubContext;
            _mapper = mapper;
        }

        public async Task<string> AddAsync(EquiposTorneo entity)
        {


            _db.EquiposTorneos.Add(entity);
            await _db.SaveChangesAsync();
            return "The category has been created"; 

        }

        public async Task<string> DeleteAsync(int id)
        {
            var Team = await GetByIdAsync(id);

            if (Team == null) return "Category not found!";

            _db.EquiposTorneos.Remove(Team);

            await _db.SaveChangesAsync();

            return "The category has been deleted";

        }


        public async Task<IReadOnlyList<EquiposTorneo>> GetAllAsync()
        {
            return await _db.EquiposTorneos.ToListAsync();

        }


        public async Task<EquiposTorneo> GetByIdAsync(int id)
        {
            var Team = await _db.EquiposTorneos.FindAsync(id);

            if (Team == null)
            {
                throw new KeyNotFoundException($"Category with ID {id} not found.");
            }

            return Team;



        }

        public async Task<string> UpdateAsync(int id, EquiposTorneo NewEntity)
        {
            var Team = await GetByIdAsync(id);
            if (Team == null)
            {
                return "The category has not updated";

            }


            _mapper.Map(NewEntity, Team);

            await _db.SaveChangesAsync();

            return "The category has been updated";
        }
    }
}
