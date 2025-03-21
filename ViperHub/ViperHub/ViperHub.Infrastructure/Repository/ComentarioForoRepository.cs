using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ViperHub.Application.Interfaces;
using ViperHub.Domain.Models;
using ViperHub.Infrastructure.Persistence;

namespace ViperHub.Infrastructure.Repository
{
    public class ComentarioForoRepository : IComentariosForo
    {
        protected readonly ViperHubContext _db;
        protected readonly IMapper _mapper;
        public ComentarioForoRepository(ViperHubContext viperHubContext, IMapper mapper)
        {
            _db=viperHubContext;
            _mapper = mapper;
        }

        public async Task<string> AddAsync(ComentariosForo entity)
        {


            _db.ComentariosForos.Add(entity);
            await _db.SaveChangesAsync();
            return "The category has been created";
        }

        public async Task<string> DeleteAsync(int id)
        {
            var comment = await GetByIdAsync(id);

            if (comment == null) return "Category not found!";

            _db.ComentariosForos.Remove(comment);

            await _db.SaveChangesAsync();

            return "The category has been deleted";

        }


        public async Task<IReadOnlyList<ComentariosForo>> GetAllAsync()
        {
            return await _db.ComentariosForos.ToListAsync();

        }


        public async Task<ComentariosForo> GetByIdAsync(int id)
        {
            var comment = await _db.ComentariosForos.FindAsync(id);

            if (comment == null)
            {
                throw new KeyNotFoundException($"Category with ID {id} not found.");
            }

            return comment;



        }

        public async Task<string> UpdateAsync(int id, ComentariosForo NewEntity)
        {
            var comment = await GetByIdAsync(id);
            if (comment == null)
            {
                return "The category has not updated";

            }


            _mapper.Map(NewEntity, comment);

            await _db.SaveChangesAsync();

            return "The category has been updated";
        }
    }
}
