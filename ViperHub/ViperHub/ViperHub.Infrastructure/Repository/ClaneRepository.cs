using AutoMapper;
using ViperHub.Application.Interfaces;
using ViperHub.Domain.Models;
using ViperHub.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ViperHub.Infrastructure.Repository
{
    public class ClaneRepository : IClanes
    {
        protected readonly ViperHubContext _db;
        protected readonly IMapper _mapper;
        public ClaneRepository(ViperHubContext viperHubContext, IMapper mapper)
        {
            _db = viperHubContext;
            _mapper = mapper;
        }
        public async Task<string> AddAsync(Clane entity)
        {


            _db.Clanes.Add(entity);
            await _db.SaveChangesAsync();
            return "The category has been created";
        }

        public async Task<string> DeleteAsync(int id)
        {
            var clan = await GetByIdAsync(id);

            if (clan == null) return "Category not found!";

            _db.Clanes.Remove(clan);

            await _db.SaveChangesAsync();

            return "The category has been deleted";

        }


        public async Task<IReadOnlyList<Clane>> GetAllAsync()
        {
            return await _db.Clanes.ToListAsync();

        }


        public async Task<Clane> GetByIdAsync(int id)
        {
            var clan = await _db.Clanes.FindAsync(id);

            if (clan == null)
            {
                throw new KeyNotFoundException($"Category with ID {id} not found.");
            }

            return clan;



        }

        public async Task<string> UpdateAsync(int id, Clane NewEntity)
        {
            var clan = await GetByIdAsync(id);
            if (clan == null)
            {
                return "The category has not updated";

            }


            _mapper.Map(NewEntity, clan);

            await _db.SaveChangesAsync();

            return "The category has been updated";
        }

    }
}
