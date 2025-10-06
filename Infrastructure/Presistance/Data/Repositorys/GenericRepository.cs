using Domain.Common;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Presistance.Data.Repositorys
{
    public class GenericRepository<TEntity, TKey>(ApplicationDbContext _dbContext ) : IGenericRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        public async Task AddAsync(TEntity entity)=> await   _dbContext.Set<TEntity>().AddAsync(entity);
        

        public async Task<IEnumerable<TEntity>> GetAllAsync()=> await _dbContext.Set<TEntity>().ToListAsync();

        public async Task<IEnumerable<TEntity>> GetAllAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null)
        {
            IQueryable<TEntity> query = _dbContext.Set<TEntity>(); 

            if (include != null)
            {
                query = include(query);
            }

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(
        Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null)
        {
            IQueryable<TEntity> query = _dbContext.Set<TEntity>();

            if (include != null)
                query = include(query);

            if (predicate != null)
                query = query.Where(predicate);

            return await query.ToListAsync();
        }


        public async Task<TEntity?> GetByIdAsync(TKey id) => await _dbContext.Set<TEntity>().FindAsync(id);

        public async Task<TEntity?> GetByIdAsync(TKey id, Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null)
        {
            IQueryable<TEntity> query = _dbContext.Set<TEntity>();

            if (include != null)
                query = include(query);

            return await query.FirstOrDefaultAsync(e => e.Id.Equals(id));
        }

        public void RemoveAsync(TEntity entity)=>_dbContext.Set<TEntity>().Remove(entity);
        

        

        public void UpdateAsync(TEntity entity)=> _dbContext.Set<TEntity>().Update(entity);
        
    }
}
