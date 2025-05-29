using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookRepository.Repository
{
    public interface IGenericRepository<T, TKey> where T: class
    {
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null);
        Task<T?> GetByIdAsync(TKey Id);
        Task<T>AddAsync(T item);
        Task UpdateAsync(T item);
        Task DeleteAsync(TKey Id);

    }
}
