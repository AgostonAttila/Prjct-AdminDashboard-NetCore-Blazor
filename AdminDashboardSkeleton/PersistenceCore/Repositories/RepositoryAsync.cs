using Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using PersistenceCore.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceCore.Repositories
{
    public class RepositoryAsync<T> : IRepositoryAsync<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;
        //protected readonly DbSet<TEntity> _entities;

        public RepositoryAsync(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<IReadOnlyList<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbContext.Set<T>().AddRangeAsync(entities);
            await _dbContext.SaveChangesAsync();
            return await _dbContext.Set<T>()
                .AsNoTracking()
                .ToListAsync();
        }

        public virtual async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task<IReadOnlyList<T>> UpdateRangeAsync(IEnumerable<T> entities)
        {
            _dbContext.Set<T>().UpdateRange(entities);
            await _dbContext.SaveChangesAsync();
            return await _dbContext.Set<T>()
                .AsNoTracking()
                .ToListAsync();
        }

        public virtual async Task RemoveAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task RemoveRangeAsync(IEnumerable<T> entities)
        {
            _dbContext.Set<T>().RemoveRange(entities);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public virtual async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _dbContext
                 .Set<T>()
                 .ToListAsync();
        }

        public virtual async Task<IReadOnlyList<T>> GetPagedReponseAsync(int pageNumber, int pageSize)
        {
            return await _dbContext
                .Set<T>()
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();
        }

        public virtual async Task<IReadOnlyList<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().Where(predicate)
                .ToListAsync();
        }

        public virtual async Task<T> GetSingleOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().FirstOrDefaultAsync(predicate);
        }
    }
}



//Without Async

/*
   public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {

        protected readonly DbContext _context;
        protected readonly DbSet<TEntity> _entities;

        public Repository(DbContext context)
        {
            _context = context;
            _entities = context.Set<TEntity>();
        }

        public virtual void Add(TEntity entity)
        {
            if (entity != null)
                _entities.Add(entity);
        }

        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            if(entities!= null)
            _entities.AddRange(entities);
        }


        public virtual void Update(TEntity entity)
        {
            _entities.Update(entity);
        }

        public virtual void UpdateRange(IEnumerable<TEntity> entities)
        {
            _entities.UpdateRange(entities);
        }



        public virtual void Remove(TEntity entity)
        {
            _entities.Remove(entity);
        }

        public virtual void RemoveRange(IEnumerable<TEntity> entities)
        {
            _entities.RemoveRange(entities);
        }


        public virtual int Count()
        {
            return _entities.Count();
        }


        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.Where(predicate);
        }

        public virtual TEntity GetSingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.SingleOrDefault(predicate);
        }

        public virtual TEntity Get(string id)
        {
            return _entities.Find(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _entities.AsNoTracking().ToList();
        }
    }
 */

