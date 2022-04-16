using System;
using System.Threading;
using Microsoft.Extensions.DependencyInjection;
using Reko.Business.ApiRequestFramework;
using Reko.Business.ApiRequestFramework.ApiRequests;
using Reko.Contracts.Managers;
using Reko.Models.Dto;

namespace Reko.Business.DataCollectors
{
    public class DataCollectorManager : IDataCollectorManager
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private static readonly object _locker = new object();

        public DataCollectorManager(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public string Collect(DateTime from, DateTime to, CancellationToken cancellationToken)
        {
            lock (_locker)
            {
                using var scope = _serviceScopeFactory.CreateScope();

                var tvShowManager = scope.ServiceProvider.GetService<ICatalogDataCollector<TVShowDto>>();
                var movieManager = scope.ServiceProvider.GetService<ICatalogDataCollector<MovieDto>>();

                tvShowManager
                    .CollectData(MovieDbFactory.Create<ApiTVShowRequest>().Value, from, to, cancellationToken).GetAwaiter().GetResult();
                movieManager
                    .CollectData(MovieDbFactory.Create<ApiMovieRequest>().Value, from, to, cancellationToken).GetAwaiter().GetResult();

                return "Successfully updated";
            }
        }
    }
}