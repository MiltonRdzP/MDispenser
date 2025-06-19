using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDispenser.Application.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        // Read operations
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<IReadOnlyList<T>> GetPagedAsync(int pageNumber, int pageSize);

        // Write operations
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);

        // Utility
        Task<bool> ExistsAsync(int id);
    }
}
