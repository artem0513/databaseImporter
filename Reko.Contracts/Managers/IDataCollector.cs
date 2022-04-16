using System;
using System.Threading;
using System.Threading.Tasks;
using Reko.Contracts.ApiRequestFramework;

namespace Reko.Contracts.Managers
{
    public interface ICatalogDataCollector<TDto>
    {
        Task CollectData<TId>(IApiCatalogRequest<TDto, TId> api, DateTime from, DateTime to, CancellationToken cancellationToken);
    }
}