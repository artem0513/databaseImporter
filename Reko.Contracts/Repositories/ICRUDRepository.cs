using System.Collections.Generic;
using System.Threading.Tasks;

namespace Reko.Contracts.Repositories
{
    public interface ICRUDRepository<TDto, TId>
    {
        Task<IEnumerable<TId>> AddIfNotExistent(IEnumerable<TDto> dtos);
        Task<IEnumerable<TDto>> Get();
        Task<TDto> Get(TId id);
        Task<bool> Update(TDto dto);
        Task Add(TDto dto);
        Task Add(IEnumerable<TDto> dtos);
        Task Delete(TId id);
    }
}