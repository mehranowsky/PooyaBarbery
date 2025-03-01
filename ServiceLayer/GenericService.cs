using Microsoft.EntityFrameworkCore;
using ModelLayer.Context;
using ModelLayer.Models;

namespace ServiceLayer
{
    public class GenericService<T> : IGenericService<T> where T : BaseEntity
    {
        private readonly BarberyDbContext _context;
        private readonly DbSet<T> _table;
        public GenericService(BarberyDbContext context)
        {
            _context = context;
            _table = context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return _table.ToList();
        }

        public T GetEntity(int id)
        {
            return _table.Find(id);
        }
        public bool Add(T entity)
        {
            try
            {
                _table.Add(entity);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(T entity)
        {
            try
            {
                _table.Entry(entity).State = EntityState.Modified;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(T entity)
        {
            try
            {
                _table.Entry(entity).State = EntityState.Deleted;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var entity = GetEntity(id);
                _table.Entry(entity).State = EntityState.Deleted;
                return true;
            }
            catch
            {
                return false;
            }
        }                       
        public void Save()
        {
            _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
