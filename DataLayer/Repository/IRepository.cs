using DataLayer.Models;
using System.Linq.Expressions;

namespace DataLayer.Repository
{
    public interface IRepository<T> where T:class
    {        
        Task<PaginatedResult<T>> GetAllAsync(int pageNumber, int pageSize, Expression<Func<T, bool>>? filter = null);
        Task<T?> GetByIdAsync(int id);
        Task<bool> AddAsync(T entity);
        Task UpdateAsync(T entity);                
    }
}
