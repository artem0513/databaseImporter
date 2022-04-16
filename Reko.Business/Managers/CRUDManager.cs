using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Reko.Contracts.Managers;
using Reko.Contracts.Repositories;
using Reko.Data;
using Reko.Models.Dto;

namespace Reko.Business.Managers
{
    public abstract class CRUDManager<TEntity, TDto, TRepository, TId> : ICRUDManager<TEntity, TDto, TId>
        where TEntity : class, IMappableEntity<TEntity, TDto, TId>
        where TDto : BaseDto<TId>
        where TRepository : ICRUDRepository<TDto, TId>
    {
        protected TRepository Repository { get; set; }

        protected CRUDManager(TRepository repository)
        {
            Repository = repository;
        }

        public async Task AddIfNotExistent(IEnumerable<TDto> dtos, CancellationToken cancellationToken)
        {
            if (dtos == null)
            {
                throw new ArgumentNullException(nameof(dtos));
            }

            await Repository.AddIfNotExistent(dtos, cancellationToken);
        }

        public async Task<IEnumerable<TDto>> Get(CancellationToken cancellationToken)
        {
            return await Repository.Get(cancellationToken);
        }

        public async Task<TDto> Get(TId id, CancellationToken cancellationToken)
        {
            return await Repository.Get(id, cancellationToken);
        }

        public async Task<bool> Update(TDto dto, CancellationToken cancellationToken)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            return await Repository.Update(dto, cancellationToken);
        }

        public async Task Add(TDto dto, CancellationToken cancellationToken)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            await Repository.Add(dto, cancellationToken);
        }

        public async Task Add(IEnumerable<TDto> dtos, CancellationToken cancellationToken)
        {
            if (dtos == null)
            {
                throw new ArgumentNullException(nameof(dtos));
            }

            await Repository.Add(dtos, cancellationToken);
        }

        public async Task Delete(TId id, CancellationToken cancellationToken)
        {
            await Repository.Delete(id, cancellationToken);
        }
    }
}