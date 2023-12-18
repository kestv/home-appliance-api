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
        public async Task<T> AddAsync(T entity)
        {
            using var context = new HomeApplianceContext();

            var record = await context.AddAsync(entity);

            await context.SaveChangesAsync();

            return record.Entity;
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            using var context = new HomeApplianceContext();

            var record = context.Remove(entity);

            await context.SaveChangesAsync();

            return record != null;
        }

        public async Task<T?> GetAsync(Expression<Func<T, bool>> expression)
        {
            using var context = new HomeApplianceContext();

            return await context.Set<T>().FirstOrDefaultAsync(expression);
        }

        public async Task<List<T>> ListAsync(Expression<Func<T, bool>> expression)
        {
            using var context = new HomeApplianceContext();

            return await context.Set<T>().Where(expression).ToListAsync();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            using var context = new HomeApplianceContext();
            
            var record = context.Update(entity);

            await context.SaveChangesAsync();

            return record.Entity;
        }
    }
}
