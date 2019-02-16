using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JabulaniHubTiger.Service
{
    public interface IGenericService<T>
    {
        Task<IList<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> InsertAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<int> DeleteAsync(T entity);
    }
}
