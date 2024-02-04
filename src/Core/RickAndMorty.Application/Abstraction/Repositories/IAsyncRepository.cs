using RickAndMorty.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMorty.Application.Abstraction.Repositories;

public interface IAsyncRepository<TEntity, TEntityId> where TEntity : EntityBase<TEntityId>
{
    Task<TEntity> AddAsync(TEntity entity);
    Task<ICollection<TEntity>> AddRangeAsync(ICollection<TEntity> entities);
}
