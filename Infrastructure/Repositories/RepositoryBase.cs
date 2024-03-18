using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : BaseEntity
    {
        protected readonly HomeApplianceContext Context;

        public RepositoryBase(HomeApplianceContext context)
        {
            Context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            var record = await Context.AddAsync(entity);

            await Context.SaveChangesAsync();

            return record.Entity;
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            var record = Context.Remove(entity);

            await Context.SaveChangesAsync();

            return record != null;
        }

        public async Task<T?> GetAsync(Expression<Func<T, bool>> expression)
        {
            return await Context.Set<T>().FirstOrDefaultAsync(expression);
        }

        public async Task<List<T>> ListAsync(Expression<Func<T, bool>> expression)
        {
            return await Context.Set<T>().Where(expression).ToListAsync();
        }

        public async Task<T> UpdateAsync(T entity)
        {            
            var record = Context.Update(entity);

            await Context.SaveChangesAsync();

            return record.Entity;
        }
    }
}
