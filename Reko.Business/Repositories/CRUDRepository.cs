using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Reko.Contracts.Repositories;
using Reko.Data;
using Reko.Models.Dto;

namespace Reko.Business.Repositories
{
    public abstract class CRUDRepository<TEntity, TDto, TContext, TId> : ICRUDRepository<TDto, TId> where TContext : DbContext
        where TEntity : class, IMappableEntity<TEntity, TDto, TId>, new()
        where TDto : BaseDto<TId>
    {
        protected TContext Context { get; }

        protected CRUDRepository(TContext context)
        {
            Context = context;
        }

        public virtual async Task AddIfNotExistent(IEnumerable<TDto> dtos, CancellationToken cancellationToken)
        {
            if (dtos == null)
            {
                throw new ArgumentNullException(nameof(dtos));
            }

            var dbSet = Context.Set<TEntity>();
            var entities = await dbSet.AsQueryable().ToArrayAsync(cancellationToken);
            var entitiesIds = entities.Select(x => x.Id).ToArray();
            var entitiesToAdd = dtos.Where(x => !entitiesIds.Contains(x.Id)).Select(x => new TEntity().FromDto(x)).ToArray();

            await Context.Set<TEntity>().AddRangeAsync(entitiesToAdd);

            await Context.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<TId>> AddIfNotExistentAndGetIds(IEnumerable<TDto> dtos, CancellationToken cancellationToken)
        {
            if (dtos == null)
            {
                throw new ArgumentNullException(nameof(dtos));
            }

            var dbSet = Context.Set<TEntity>();
            var entities = await dbSet.AsQueryable().ToArrayAsync(cancellationToken);
            var entitiesIds = entities.Select(x => x.Id).ToArray();
            var entitiesToAdd = dtos.Where(x => !entitiesIds.Contains(x.Id)).Select(x => new TEntity().FromDto(x)).ToArray();

            await Context.Set<TEntity>().AddRangeAsync(entitiesToAdd, cancellationToken);

            await Context.SaveChangesAsync(cancellationToken);

            return entitiesToAdd.Select(x => x.Id);
        }

        public virtual async Task<IEnumerable<TDto>> Get(CancellationToken cancellationToken)
        {
            return await Context.Set<TEntity>().Select(x => x.ToDto()).ToArrayAsync(cancellationToken);
        }

        public virtual async Task<TDto> Get(TId id, CancellationToken cancellationToken)
        {
            return (await Context.Set<TEntity>().FindAsync(id, cancellationToken)).ToDto();
        }

        public virtual async Task<bool> Update(TDto dto, CancellationToken cancellationToken)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            var result = await Context.Set<TEntity>().FindAsync(dto.Id, cancellationToken);
            if (result != null)
            {
                result.FromDto(dto);
                return true;
            }

            return false;
        }

        public virtual async Task Add(TDto dto, CancellationToken cancellationToken)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            await Context.Set<TEntity>().AddAsync(new TEntity().FromDto(dto), cancellationToken);
        }

        public virtual async Task Add(IEnumerable<TDto> dtos, CancellationToken cancellationToken)
        {
            if (dtos == null)
            {
                throw new ArgumentNullException(nameof(dtos));
            }

            await Context.Set<TEntity>().AddRangeAsync(dtos.Select(x => new TEntity().FromDto(x)), cancellationToken);
        }

        public virtual async Task Delete(TId id, CancellationToken cancellationToken)
        {
            var result = await Context.Set<TEntity>().FindAsync(id, cancellationToken);
            if (result != null)
            {
                Context.Set<TEntity>().Remove(result);
            }
        }
    }
}