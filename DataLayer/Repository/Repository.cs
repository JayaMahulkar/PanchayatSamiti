using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataLayer.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly PanchayatSamitiContext _context;
        protected readonly DbSet<T> _dbSet;

        public Repository(PanchayatSamitiContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }


        public async Task<bool> AddAsync(T entity)
        {
            try
            {
                await _dbSet.AddAsync(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public async Task<PaginatedResult<T>> GetAllAsync(int pageNumber, int pageSize, Expression<Func<T, bool>>? filter = null)
        {
            if (pageNumber <= 0) pageNumber = 1;
            if (pageSize <= 0) pageSize = 10;

            IQueryable<T> query = _context.Set<T>();

            if (filter != null)
                query = query.Where(filter);

            var totalRecords = await query.CountAsync();
            var result = new PaginatedResult<T>
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalCount = totalRecords
            };

            var skip = (pageNumber - 1) * pageSize;
           
            result.Data = await query.Skip(skip).Take(pageSize).ToListAsync();

            return result;
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

    }
}
