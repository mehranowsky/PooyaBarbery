using Microsoft.EntityFrameworkCore;
using ModelLayer.Context;
using ModelLayer.Models;

namespace ServiceLayer
{
    public class GenericService<T> : IGenericService<T> where T : BaseEntity
    {
        protected readonly BarberyDbContext _context;
        private readonly DbSet<T> _table;
        public GenericService(BarberyDbContext context)
        {
            _context = context;
            _table = context.Set<T>();
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            return await _table.ToListAsync();
        }

        public async Task<T> GetEntity(int id)
        {
            return await _table.FindAsync(id);
        }

        public async Task<bool> Add(T entity)
        {
            try
            {
                await _table.AddAsync(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> Update(T entity)
        {
            try
            {
                _table.Update(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Delete(T entity)
        {
            try
            {
                _table.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var entity = await GetEntity(id);
                _table.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }                             

        public void Dispose()
        {
            _context.DisposeAsync();
        }
    }
}
