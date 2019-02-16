using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabulaniHubTiger.Repository
{
    public interface IGenericRepository<T>
    {
        Task<T> GetAsync(int id);
        IQueryable<T> Query();
        Task<T> InsertAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<int> DeleteAsync(T entity);
    }
}
