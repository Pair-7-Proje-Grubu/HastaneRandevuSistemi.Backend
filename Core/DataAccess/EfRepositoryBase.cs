using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace Core.DataAccess
{
    public class EfRepositoryBase<TEntity, TContext> : IRepository<TEntity>, IAsyncRepository<TEntity>
        where TEntity : BaseEntity
        where TContext : DbContext
    {
        private readonly TContext context;

        public EfRepositoryBase(TContext context)
        {
            this.context = context;
        }

        public void Add(TEntity entity)
        {
            context.Add(entity);
            context.SaveChanges();
        }

        public async Task AddAsync(TEntity entity)
        {

            await context.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task AddRangeAsync(ICollection<TEntity> entity)
        {
            await context.AddRangeAsync(entity);
            await context.SaveChangesAsync();
        }


        public void Delete(TEntity entity)
        {
            context.Remove(entity);
            context.SaveChanges();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            context.Remove(entity);
            await context.SaveChangesAsync();   
        }

        public async Task DeleteRangeAsync(ICollection<TEntity> entity)
        {
            context.RemoveRange(entity);
            await context.SaveChangesAsync();
        }



        public TEntity? Get(Expression<Func<TEntity, bool>>? predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            bool asNoTracking = false)
        {
            IQueryable<TEntity> queryable = context.Set<TEntity>();

            if (asNoTracking)
                queryable = queryable.AsNoTracking();

            if (include != null)
                queryable = include(queryable);

            if (orderBy != null)
                queryable = orderBy(queryable);

            if (predicate != null)
            {
                return queryable.FirstOrDefault(predicate);
            }
            else
            {
                return queryable.FirstOrDefault();
            }
        }

        public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>>? predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            bool asNoTracking = false)
        {
            IQueryable<TEntity> queryable = context.Set<TEntity>();

            if (asNoTracking)
                queryable = queryable.AsNoTracking();

            if (include != null)
                queryable = include(queryable);


            if (orderBy != null)
                queryable = orderBy(queryable);

            if (predicate != null)
            {
                return await queryable.FirstOrDefaultAsync(predicate);
            }
            else
            {
                return await queryable.FirstOrDefaultAsync();
            }
        }


        public List<TEntity> GetList(Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            bool asNoTracking = false)
        {
            IQueryable<TEntity> queryable = context.Set<TEntity>();

            if (asNoTracking)
                queryable = queryable.AsNoTracking();

            if (filter != null)
                queryable = queryable.Where(filter);

            if (include != null)
                queryable = include(queryable);

            if (orderBy != null)
                queryable = orderBy(queryable);

            return queryable.ToList();
        }

  
        public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            bool asNoTracking = false)
        {
            IQueryable<TEntity> queryable = context.Set<TEntity>();


            if (asNoTracking)
                queryable = queryable.AsNoTracking();

            if (predicate != null)
                queryable = queryable.Where(predicate);

            if (include != null)
                queryable = include(queryable);

            if (orderBy != null)
                queryable = orderBy(queryable);

            return await queryable.ToListAsync();
        }

        public void Update(TEntity entity)
        {
            context.Update(entity);
            context.SaveChanges();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            context.Update(entity);
            await context.SaveChangesAsync();
        }


    }
}
