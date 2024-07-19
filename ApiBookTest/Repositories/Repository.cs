using System.Linq.Expressions;
using ApiBookTest.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiBookTest.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly BDBookTestContext _context;

        public Repository(BDBookTestContext context)
        {
            _context = context;
        }

        public async Task<List<T>> ListRecords(Expression<Func<T, bool>>? predicate = null, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _context.Set<T>();

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (includes != null && includes.Any())
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }

            return await query.ToListAsync();
        }

        public async Task<T> CreateRecord(T entidad)
        {
            _context.Set<T>().Add(entidad);
            await _context.SaveChangesAsync();
            return entidad;
        }

        public async Task<T> UpdateRecord(T entidad)
        {
            _context.Set<T>().Update(entidad);
            await _context.SaveChangesAsync();
            return entidad;
        }

        public async Task<bool> DeleteRecord(int id)
        {
            var entidad = await _context.Set<T>().FindAsync(id);
            if (entidad == null)
            {
                return false;
            }

            _context.Set<T>().Remove(entidad);
            await _context.SaveChangesAsync();
            return true;
        }
    }

    public interface IRepository<T>
    {
        Task<List<T>> ListRecords(Expression<Func<T, bool>>? predicate = null, params Expression<Func<T, object>>[]? includes);
        Task<T> CreateRecord(T entidad);
        Task<T> UpdateRecord(T entidad);
        Task<bool> DeleteRecord(int id);
    }

}
