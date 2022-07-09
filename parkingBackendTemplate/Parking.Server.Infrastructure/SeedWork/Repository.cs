using Microsoft.EntityFrameworkCore;
using Parking.Server.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Parking.Server.Infrastructure.SeedWork
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        //protected readonly ParkingIntegratedControlCenterContext context;
        protected readonly DbContext context;
        public Repository(DbContext _context)
        {
            context = _context ?? throw new ArgumentNullException(nameof(_context));
        }


        public async Task AddAsync(TEntity entity)
        {
            await context.Set<TEntity>().AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await context.Set<TEntity>().AddRangeAsync(entities);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return context.Set<TEntity>().Where(predicate);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await context.Set<TEntity>().ToListAsync();
        }

        public void Remove(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            context.Set<TEntity>().RemoveRange(entities);
        }

        public Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return context.Set<TEntity>().SingleOrDefaultAsync(predicate);
        }
    }
}
