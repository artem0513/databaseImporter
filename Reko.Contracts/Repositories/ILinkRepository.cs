using System.Threading;
using System.Threading.Tasks;
using Reko.Contracts.Containers;
using Reko.Models.Dto;

namespace Reko.Contracts.Repositories
{
    public interface ILinkRepository<in TContainer, TDto, TId> : ICRUDRepository<TDto, TId> where TDto: BaseDto<TId>
    where TContainer : IUniqueDataContainer<TDto, TId> 
    {
        Task LinkData(TContainer container, CancellationToken cancellationToken);
    }
}