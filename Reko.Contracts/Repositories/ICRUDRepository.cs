using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Reko.Contracts.Repositories
{
    public interface ICRUDRepository<TDto, TId>
    {
        Task AddIfNotExistent(IEnumerable<TDto> dtos, CancellationToken cancellationToken);
        Task<IEnumerable<TId>> AddIfNotExistentAndGetIds(IEnumerable<TDto> dtos, CancellationToken cancellationToken);
        Task<IEnumerable<TDto>> Get(CancellationToken cancellationToken);
        Task<TDto> Get(TId id, CancellationToken cancellationToken);
        Task<bool> Update(TDto dto, CancellationToken cancellationToken);
        Task Add(TDto dto, CancellationToken cancellationToken);
        Task Add(IEnumerable<TDto> dtos, CancellationToken cancellationToken);
        Task Delete(TId id, CancellationToken cancellationToken);
    }
}