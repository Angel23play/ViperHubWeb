using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViperHub.Application.Core
{
    public interface BaseEntity <T> where T : class
    {
            Task<IReadOnlyList<T>> GetAllAsync();
            Task<T> GetByIdAsync(int id);
            Task<string> AddAsync(T entity);
            Task<string> UpdateAsync(int id, T entity);
            Task<string> DeleteAsync(int id);
        
    }
}
