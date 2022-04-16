using System;
using System.Threading;
using System.Threading.Tasks;
using Reko.Contracts.Containers;
using Reko.Contracts.EntityStorages;
using Reko.Contracts.Repositories;
using Reko.Data;
using Reko.Data.Entities;
using Reko.Models.Dto;

namespace Reko.Business.Repositories
{
    public abstract class LinkRepositoryBase<TEntity, TDto, TDataContainer, TEntityStorage, TId> : CRUDRepository<TEntity, TDto, RekoDbContext, TId>,
        ILinkRepository<TDataContainer, TDto, TId>
        where TDto : BaseDto<TId>
        where TEntity : class, IMappableEntity<TEntity, TDto, TId>, new()
        where TDataContainer : IUniqueDataContainer<TDto, TId>
        where TEntityStorage : IEntityStorage<TDataContainer, TDto, TId>
    {
        protected TEntityStorage EntityStorage { get; }

        protected LinkRepositoryBase(RekoDbContext context, TEntityStorage entityStorage) : base(context)
        {
            EntityStorage = entityStorage;
        }

        public async Task LinkData(TDataContainer container, CancellationToken cancellationToken)
        {
            if (container == null)
            {
                throw new ArgumentNullException(nameof(container));
            }

            await LinkEntities(container, cancellationToken);
            await Context.SaveChangesAsync(cancellationToken);
            EntityStorage.Clear();
        }

        protected abstract Task LinkEntities(TDataContainer container, CancellationToken cancellationToken);
    }
}