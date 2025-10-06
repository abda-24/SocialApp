using Domain.Common;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUnitOfWork
    {

        IGenericRepository<TEntity, Tkey> GetRepository<TEntity, Tkey>() where TEntity : BaseEntity<Tkey>;
           Task<int> SaveChangesAsync();
    
    }
}
