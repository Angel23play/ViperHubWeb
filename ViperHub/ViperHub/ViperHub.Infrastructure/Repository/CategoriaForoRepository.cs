using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;
using ViperHub.Application.Foro.Dto;
using ViperHub.Application.Interfaces;
using ViperHub.Domain.Models;
using ViperHub.Infrastructure.Persistence;

namespace ViperHub.Infrastructure.Repository
{
    public class CategoriaForoRepository : ICategoriaForo
    {
        protected readonly ViperHubContext _db;
       
        public CategoriaForoRepository(ViperHubContext viperHubContext)
        {
            _db = viperHubContext;
        }

       public async Task<string> AddAsync(CategoriaForoDto entity)
        {

            CategoriasForo categorias = new CategoriasForo { Name=entity.Name,
              
            };
        
            _db.CategoriasForos.Add(categorias);
            await _db.SaveChangesAsync();
            return "The category has been created";
        }

        public async Task<string> DeleteAsync(int id)
        {
           var category = await GetByIdAsync(id);

            if (category == null) return "Category not found!";
            
            _db.CategoriasForos.Remove(category);

            await _db.SaveChangesAsync();

            return "The category has been deleted";

        }

     
        public async Task<IReadOnlyList<CategoriaForoDto>> GetAllAsync()
        {
            return await _db.CategoriasForos.ToListAsync();
      
        }

        
        public async Task<CategoriaForoDto> GetByIdAsync(int id)
        {
            return await _db.CategoriasForos.FindAsync(id);
             

        }
        
        public async Task<string> UpdateAsync(int id)
        {
            var category = await GetByIdAsync(id);
            if (category == null)
            {
                return "The category has not updated";

            }
            
          
           
             await  _db.SaveChangesAsync();
            
            return "The category has been updated";
        }
      



    }


}
