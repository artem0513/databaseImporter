using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reko.Contracts.ApiRequestFramework;
using Reko.Contracts.Managers;
using Reko.Models.Dto;

namespace Reko.Business.DataCollectors
{
    public sealed class CatalogDataCollector<TDto> : ICatalogDataCollector<TDto>
    {
        private readonly ICatalogManager<TDto> _catalogManager;
        private readonly int _takeBy;

        public CatalogDataCollector(ICatalogManager<TDto> catalogManager)
        {
            _catalogManager = catalogManager;
            _takeBy = typeof(TDto) == typeof(MovieDto) ? 150 : 50;
        }

        public async Task CollectData<TId>(IApiCatalogRequest<TDto, TId> api, DateTime from, DateTime to)
        {
            foreach (var dateTime in GetDatesByOneDay(from, to))
            {
                var ids = new Queue<TId>(await api.GetIds(dateTime));
                while (ids.Count > 0)
                {
                    await _catalogManager.SaveData(await GetData(api, GetPartOfElements(ids)));
                }
            }
        }

        private static async Task<IEnumerable<TObject>> GetData<TObject, TId>(IDetailsApiRequest<TObject, TId> movieApi, IEnumerable<TId> ids)
        {
            return (await Task.WhenAll(ids.Select(movieApi.FindByIdAsync))).Select(x => x.Item);
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

        private static IEnumerable<DateTime> GetDatesByOneDay(DateTime from, DateTime to)
        {
            for (var year = from.Year; year <= to.Year; year++)
            {
                var isLastYear = year == to.Year;
                var months = isLastYear ? to.Month : 12;
                for (var month = from.Month; month <= months; month++)
                {
                    var days = isLastYear && to.Month == month ? to.Day : DateTime.DaysInMonth(year, month);
                    for (var day = from.Day; day <= days; day++) yield return new DateTime(year, month, day);
                }
            }
        }
    }
}