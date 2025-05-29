using AddressBookRepository.DbContextClass;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookRepository.Repository
{
    public class GenericRepository<T, TKey> : IGenericRepository<T, TKey> where T : class
    {
        private readonly DbContextApp _dbContext;
        private readonly DbSet<T> entity;

        public GenericRepository(DbContextApp dbContext)
        {
            _dbContext = dbContext;
            entity = _dbContext.Set<T>();
        }
        public async Task<T> AddAsync(T item)
        {
           var newEntity= await entity.AddAsync(item);
            await saveAsync();
            return newEntity.Entity;
        }

        public async Task DeleteAsync(TKey Id)
        {
            var deletedEntity = await entity.FindAsync(Id);
            if (entity == null)
                throw new Exception("Entity not found");
           
            entity.Remove(deletedEntity);
            await saveAsync();
            
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null)
        {
            return filter == null
                ? await entity.ToListAsync()
                : await entity.Where(filter).ToListAsync();
           
        }

        public async Task<T?> GetByIdAsync(TKey Id)
        {
            return await entity.FindAsync(Id);
        }

        public async Task UpdateAsync(T item)
        {
             entity.Update(item);
            await saveAsync();
        }
        private async Task saveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
        public async Task<T?> Get(Expression<Func<T, bool>> filter)
        {
            return await entity.FirstOrDefaultAsync(filter);
        }
    }
}
