using System.Collections.Generic;
using System.Linq;
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

        public virtual async Task<IEnumerable<TId>> AddIfNotExistent(IEnumerable<TDto> dtos)
        {
            var dbSet = Context.Set<TEntity>();
            var entities = await dbSet.AsQueryable().ToArrayAsync();
            var entitiesIds = entities.Select(x => x.Id).ToArray();
            var entitiesToAdd = dtos.Where(x => !entitiesIds.Contains(x.Id)).Select(x => new TEntity().FromDto(x)).ToArray();

            await Context.AddRangeAsync(entitiesToAdd);

            await Context.SaveChangesAsync();

            return entitiesToAdd.Select(x => x.Id);
        }

        public virtual async Task<IEnumerable<TDto>> Get()
        {
            return await Context.Set<TEntity>().Select(x => x.ToDto()).ToArrayAsync();
        }

        public virtual async Task<TDto> Get(TId id)
        {
            return (await Context.Set<TEntity>().FindAsync(id)).ToDto();
        }

        public virtual async Task<bool> Update(TDto dto)
        {
            var result = await Context.Set<TEntity>().FindAsync(dto.Id);
            if (result != null)
            {
                result.FromDto(dto);
                return true;
            }

            return false;
        }

        public virtual async Task Add(TDto dto)
        {
            await Context.Set<TEntity>().AddAsync(new TEntity().FromDto(dto));
        }

        public virtual async Task Add(IEnumerable<TDto> dtos)
        {
            await Context.Set<TEntity>().AddRangeAsync(dtos.Select(x => new TEntity().FromDto(x)));
        }

        public virtual async Task Delete(TId id)
        {
            var result = await Context.Set<TEntity>().FindAsync(id);
            if (result != null)
            {
                Context.Set<TEntity>().Remove(result);
            }
        }
    }
}