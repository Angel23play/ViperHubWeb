using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ViperHub.Domain.Models;
using ViperHub.Infrastructure.Persistence;
using ViperHub.Infrastructure.RepoInterfaces;

namespace ViperHub.Infrastructure.Repository
{

    public class TemasForoRepository : ITemasForo
    {
        protected readonly ViperHubContext _db;
        protected readonly IMapper _mapper;
        public TemasForoRepository(ViperHubContext viperHubContext, IMapper mapper)
        {
            _db=viperHubContext;
            _mapper = mapper;
        }

        public async Task<string> AddAsync(TemasForo entity)
        {


            _db.TemasForos.Add(entity);
            await _db.SaveChangesAsync();
            return "The category has been created";

        }

        public async Task<string> DeleteAsync(int id)
        {
            var themes = await GetByIdAsync(id);

            if (themes == null) return "Category not found!";

            _db.TemasForos.Remove(themes);

            await _db.SaveChangesAsync();

            return "The category has been deleted";

        }


        public async Task<IReadOnlyList<TemasForo>> GetAllAsync()
        {
            return await _db.TemasForos.ToListAsync();

        }


        public async Task<TemasForo> GetByIdAsync(int id)
        {
            var themes = await _db.TemasForos.FindAsync(id);

            if (themes == null)
            {
                throw new KeyNotFoundException($"Category with ID {id} not found.");
            }

            return themes;



        }

        public async Task<string> UpdateAsync(int id, TemasForo NewEntity)
        {
            var themes = await GetByIdAsync(id);
            if (themes == null)
            {
                return "The category has not updated";

            }


            _mapper.Map(NewEntity, themes);

            await _db.SaveChangesAsync();

            return "The category has been updated";
        }
    }
}
