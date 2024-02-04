using Microsoft.EntityFrameworkCore;
using RickAndMorty.Application.Abstraction.Repositories;
using RickAndMorty.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMorty.Persistence.Repositories
{
    public class EFRepositoryBase<TEntity, TEntityId, TContext> : IAsyncRepository<TEntity, TEntityId>
        where TEntity : EntityBase<TEntityId>
        where TContext : DbContext
    {
        protected readonly TContext Context;

        public EFRepositoryBase(TContext context)
        {
            Context = context;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            entity.CreatedDate = DateTime.Now;
            await Context.AddAsync(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<ICollection<TEntity>> AddRangeAsync(ICollection<TEntity> entities)
        {
            foreach (TEntity entity in entities)
                entity.CreatedDate = DateTime.Now;
            await Context.AddRangeAsync(entities);
            await Context.SaveChangesAsync();
            return entities;
        }
    }
}
