using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Reko.Contracts.Repositories;
using Reko.Data;
using Reko.Models.Dto;

namespace Reko.Contracts.Managers
{
    public interface ICRUDManager<TEntity, TDto, in TId> where TEntity : class, IMappableEntity<TEntity, TDto, TId>
        where TDto : BaseDto<TId>
    {
        Task AddIfNotExistent(IEnumerable<TDto> dtos, CancellationToken cancellationToken);
        Task<IEnumerable<TDto>> Get(CancellationToken cancellationToken);
        Task<TDto> Get(TId id, CancellationToken cancellationToken);
        Task<bool> Update(TDto dto, CancellationToken cancellationToken);
        Task Add(TDto dto, CancellationToken cancellationToken);
        Task Add(IEnumerable<TDto> dtos, CancellationToken cancellationToken);
        Task Delete(TId id, CancellationToken cancellationToken);
    }
}