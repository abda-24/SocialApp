using Domain.Common;
using System.Linq.Expressions;

namespace Domain.Interfaces
{
    public interface IGenericRepository<TEntity,Tkey> where TEntity : BaseEntity<Tkey>
    {

        Task<TEntity?> GetByIdAsync(Tkey id, Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null);
        Task<IEnumerable<TEntity>> GetAllAsync(
            Expression<Func<TEntity, bool>>? predicate = null,
            Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null);

        Task AddAsync(TEntity entity);
        void RemoveAsync(TEntity entity);
        void UpdateAsync(TEntity entity);
    }
}
