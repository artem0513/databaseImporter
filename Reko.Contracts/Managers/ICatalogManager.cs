using System.Collections.Generic;
using System.Threading.Tasks;
using Reko.Contracts.Repositories;

namespace Reko.Contracts.Managers
{
    public interface ICatalogManager<TDto>
    {
        Task SaveData(IEnumerable<TDto> data);
    }
}