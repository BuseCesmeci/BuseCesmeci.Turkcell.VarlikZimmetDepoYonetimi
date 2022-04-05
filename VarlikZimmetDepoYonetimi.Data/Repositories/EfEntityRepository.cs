using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VarlikZimmetDepoYonetimi.Core.IRepositories;
using VarlikZimmetDepoYonetimi.Core.Models;

namespace VarlikZimmetDepoYonetimi.Data.Repositories
{
    public class EfEntityRepository<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity ,new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using (var context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public async Task AddAsync(TEntity entity)
        {
            using (var context = new TContext())
            {
                 await context.AddAsync(entity);
                // addEntity.State = EntityState.Added;
                var value = context.SaveChanges();
            }
        }

        public Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                var deleteEntity = context.Entry(entity);
                deleteEntity.State = EntityState.Deleted;
                var value = context.SaveChanges();
            }
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }


        public async Task DeleteAsync(TEntity entity)
        {
            using (var context = new TContext())
            {
                var added = context.Entry(entity);
                added.State = EntityState.Deleted;
                var value = await context.SaveChangesAsync();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            List<TEntity> entities;
            using (var context = new TContext())
            {
                entities = await context.Set<TEntity>().ToListAsync();
            }
            return entities;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> condition = null)
        {
            List<TEntity> entities;
            using (var context = new TContext())
            {
                entities = await context.Set<TEntity>().ToListAsync();
            }
            return entities;
        }

        public void Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                 var value = context.SaveChanges();
            }
        }

        public async Task UpdateAsync(TEntity entity)
        {
            using (var context = new TContext())
            {
                var updated = context.Entry(entity);
                updated.State = EntityState.Modified;
                var value = await context.SaveChangesAsync();
            }
        }

        public Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> condition = null)
        {
            throw new NotImplementedException();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            using (var context = new TContext())
            {
                return await context.Set<TEntity>().FindAsync(id);
            }
        }

        public async Task SoftDelete(TEntity entity)
        {
            using (var context = new TContext())
            {
                entity.GetType().GetProperty("isActive").SetValue(entity, false);
                await context.SaveChangesAsync();
            }
        }
    }
}
