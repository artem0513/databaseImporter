using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Reko.Contracts.ApiRequestFramework;
using Reko.Contracts.Managers;
using Reko.Models.Dto;
using Serilog;

namespace Reko.Business.DataCollectors
{
    public sealed class CatalogDataCollector<TDto> : ICatalogDataCollector<TDto>
    {
        private readonly ICatalogManager<TDto> _catalogManager;
        private readonly ILogger _logger;
        private readonly int _takeBy;

        public CatalogDataCollector(ICatalogManager<TDto> catalogManager, ILogger logger)
        {
            _catalogManager = catalogManager;
            _logger = logger;
            _takeBy = typeof(TDto) == typeof(MovieDto) ? 150 : 50;
        }

        public async Task CollectData<TId>(IApiCatalogRequest<TDto, TId> api, DateTime from, DateTime to, CancellationToken cancellationToken)
        {
            if (api == null)
            {
                throw new ArgumentNullException(nameof(api));
            }

            foreach (var dateTime in GetDatesByOneMonth(from, to))
            {
                var ids = (await api.GetIds(dateTime.From, dateTime.To)).ToArray();
                _logger
                    .Information("Received ids:" + string.Join(',', ids) + " of " + typeof(TDto).Name + " from date: " + dateTime.From.ToString("yyyy-MM-dd")
                                 + " to date: " + dateTime.To.ToString("yyyy-MM-dd"));
                var remainedIds = new Queue<TId>(ids);
                while (remainedIds.Count > 0)
                {
                    var handlingIds = GetPartOfElements(remainedIds).ToArray();
                    _logger.Information("Starting handling ids: " + string.Join(',', handlingIds));
                    await _catalogManager.SaveData(await GetData(api, handlingIds), cancellationToken);
                    _logger.Information("Data was successfully received.");
                }
            }
        }

        private static async Task<IEnumerable<TObject>> GetData<TObject, TId>(IDetailsApiRequest<TObject, TId> movieApi, IEnumerable<TId> ids)
        {
            return (await Task.WhenAll(ids.Select(movieApi.FindByIdAsync))).Where(x => x != null && x.Item != null).Select(x => x.Item);
        }

        private IEnumerable<T> GetPartOfElements<T>(Queue<T> ids)
        {
            for (var i = 0; i < _takeBy; i++)
            {
                if (ids.TryDequeue(out var id))
                {
                    yield return id;
                }
                else
                {
                    yield break;
                }
            }
        }

        private static IEnumerable<(DateTime From, DateTime To)> GetDatesByOneMonth(DateTime from, DateTime to)
        {
            for (var year = from.Year; year <= to.Year; year++)
            {
                var isLastYear = year == to.Year;
                var isFirstYear = year == from.Year;
                var endMonth = isLastYear ? to.Month : 12;
                var startMonth = isFirstYear ? from.Month : 1;

                for (var month = startMonth; month <= endMonth; month++)
                {
                    var days = isLastYear && to.Month == month ? to.Day : DateTime.DaysInMonth(year, month);

                    yield return (From: new DateTime(year, month, 1), To: new DateTime(year, month, days));
                }
            }
        }
    }
}