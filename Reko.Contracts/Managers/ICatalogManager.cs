using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Reko.Contracts.Repositories;

namespace Reko.Contracts.Managers
{
    public interface ICatalogManager<in TDto>
    {
        Task SaveData(IEnumerable<TDto> data, CancellationToken cancellationToken);
    }
}