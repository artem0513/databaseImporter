using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Reko.Business.ApiRequestFramework;
using Reko.Business.ApiRequestFramework.ApiRequests;
using Reko.Contracts.Managers;
using Reko.Data.Entities;
using Reko.Models.Dto;
using Reko.Models.Models;

namespace Reko.Business.Managers
{
    public class DataCollectorManager : IDataCollectorManager
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private static readonly object _locker = new object();

        public DataCollectorManager(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public string Collect(DateTime from, DateTime to)
        {
            lock (_locker)
            {
                using var scope = _serviceScopeFactory.CreateScope();

                var tvShowManager = scope.ServiceProvider.GetService<ICatalogDataCollector<TVShowDto>>();
                var movieManager = scope.ServiceProvider.GetService<ICatalogDataCollector<MovieDto>>();

                tvShowManager
                    .CollectData(MovieDbFactory.Create<ApiTVShowRequest>().Value, from, to).GetAwaiter().GetResult();
                movieManager
                    .CollectData(MovieDbFactory.Create<ApiMovieRequest>().Value, from, to).GetAwaiter().GetResult();

                return "Successfully updated";
            }
        }
    }
}