using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ViperHub.Domain.Models;
using ViperHub.Infrastructure.Persistence;
using ViperHub.Infrastructure.RepoInterfaces;

namespace ViperHub.Infrastructure.Repository
{
    public class MultimediumRepository : IMultimedium
    {
        protected readonly ViperHubContext _db;
        protected readonly IMapper _mapper;
        public MultimediumRepository(ViperHubContext viperHubContext, IMapper mapper)
        {
            _db = viperHubContext;
            _mapper = mapper;
        }

        public async Task<string> AddAsync(Multimedium entity)
        {


            _db.Multimedia.Add(entity);
            await _db.SaveChangesAsync();
            return "The category has been created";

        }

        public async Task<string> DeleteAsync(int id)
        {
            var media = await GetByIdAsync(id);

            if (media == null) return "Category not found!";

            _db.Multimedia.Remove(media);

            await _db.SaveChangesAsync();

            return "The category has been deleted";

        }


        public async Task<IReadOnlyList<Multimedium>> GetAllAsync()
        {
            return await _db.Multimedia.ToListAsync();

        }


        public async Task<Multimedium> GetByIdAsync(int id)
        {
            var media = await _db.Multimedia.FindAsync(id);

            if (media == null)
            {
                throw new KeyNotFoundException($"Category with ID {id} not found.");
            }

            return media;



        }

        public async Task<string> UpdateAsync(int id, Multimedium NewEntity)
        {
            var media = await GetByIdAsync(id);
            if (media == null)
            {
                return "The category has not updated";

            }


            _mapper.Map(NewEntity, media);

            await _db.SaveChangesAsync();

            return "The category has been updated";
        }
    }
}
