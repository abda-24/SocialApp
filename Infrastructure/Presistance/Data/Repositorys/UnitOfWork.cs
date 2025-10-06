using Domain.Common;
using Domain.Interfaces;
using Presistance.Data.Repositorys;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IDictionary<string, object> _repositorys;

    public UnitOfWork(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
        _repositorys = new Dictionary<string, object>();
    }

    public IGenericRepository<TEntity, Tkey> GetRepository<TEntity, Tkey>()
        where TEntity : BaseEntity<Tkey>
    {
        var typeName = typeof(TEntity).Name;
        if (_repositorys.TryGetValue(typeName, out object? value))
            return (IGenericRepository<TEntity, Tkey>)value;
        else
        {
            var repo = new GenericRepository<TEntity, Tkey>(_dbContext);
            _repositorys[typeName] = repo; 
            return repo;
        }
    }

    public async Task<int> SaveChangesAsync() => await _dbContext.SaveChangesAsync();
}
