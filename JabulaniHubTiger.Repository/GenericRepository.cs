using JabulaniHubTiger.Helper.Provider;
using JabulaniHubTiger.Repository.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabulaniHubTiger.Repository
{
    public abstract class GenericRepository<T> : IGenericRepository<T>
        where T : class, new()
    {
        protected ApplicationDbContext DbContext { get; set; }
        public GenericRepository(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }
        public async Task<int> DeleteAsync(T entity)
        {
            DbContext.Set<T>().Remove(entity);
            return await DbContext.SaveChangesAsync();
        }


        public async Task<T> GetAsync(int id)
        {
            return await DbContext.FindAsync<T>(id);
        }

        public async Task<T> InsertAsync(T entity)
        {
            DbContext.Set<T>().Add(entity);
            var result = await DbContext.SaveChangesAsync();
            return result > 0 ? entity : throw new HttpException(400,"not saved");
        }

        public IQueryable<T> Query()
        {
            return DbContext.Set<T>().AsQueryable();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
            var result = await DbContext.SaveChangesAsync();
            return result > 0 ? entity : throw new HttpException(400, "not updated");

        }
    }
}
