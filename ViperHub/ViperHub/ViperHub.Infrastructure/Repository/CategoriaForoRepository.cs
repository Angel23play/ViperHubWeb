using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;
using AutoMapper;
using ViperHub.Domain.Models;
using ViperHub.Infrastructure.Persistence;
using ViperHub.Infrastructure.RepoInterfaces;

namespace ViperHub.Infrastructure.Repository
{
    public class CategoriaForoRepository : ICategoriaForo
    {
        protected readonly ViperHubContext _db;
        protected readonly IMapper _mapper;

        public CategoriaForoRepository(ViperHubContext viperHubContext, IMapper mapper)
        {
            _db = viperHubContext;
            _mapper = mapper;

        }

        public async Task<string> AddAsync(CategoriasForo entity)
        {
            try
            {
                _db.CategoriasForos.Add(entity);
                await _db.SaveChangesAsync();
                return "The category has been created";

            }
            catch (DbUpdateException ex) 
            {
                return $"Database Error: {ex.InnerException?.Message ?? ex.Message}";
            }
            catch(Exception ex)
            {
                return $"Error: {ex.Message}";
            }

        }

        public async Task<string> DeleteAsync(int id)
        {
            var category = await GetByIdAsync(id);

            if (category == null) return "Category not found!";

            _db.CategoriasForos.Remove(category);

            await _db.SaveChangesAsync();

            return "The category has been deleted";

        }


        public async Task<IReadOnlyList<CategoriasForo>> GetAllAsync()
        {
            return await _db.CategoriasForos.ToListAsync();

        }


        public async Task<CategoriasForo> GetByIdAsync(int id)
        {
            var category = await _db.CategoriasForos.FindAsync(id);

            if (category == null)
            {
                throw new KeyNotFoundException($"Category with ID {id} not found.");
            }

            return category;



        }

        public async Task<string> UpdateAsync(int id, CategoriasForo updateCategory)
        {

            var category = await GetByIdAsync(id);
            if (category == null)
            {
                return "The category has not updated";

            }


            _mapper.Map(updateCategory, category);

            await _db.SaveChangesAsync();

            return "The category has been updated";
        }




    }


}
