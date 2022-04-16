using System.Collections.Generic;
using System.Threading.Tasks;
using Reko.Models.Dto;

namespace Reko.Contracts.Repositories
{
    public interface ILinkRepository<TDto>
    {
        Task LinkData(ICollection<TDto> data);
    }
}