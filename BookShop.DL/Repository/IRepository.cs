using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.DL.Repository
{
        public interface IRepository<T, K> where T : class
        {
            Task<T> GetByIdAsync(K id);
            IQueryable<T> GetAll();
            Task<bool> InsertAsync(T entity);
            Task<bool> UpdateAsync(T entity);
            Task<bool> DeleteAsync(K id);
        }
}
