using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reko.Contracts.ApiRequestFramework;
using Reko.Models.Dto;

namespace Reko.Business.ApiRequestFramework.ApiRequests
{
    public abstract class ApiDiscoverRequestBase<TDto, T> : ApiRequestBase, IDiscoveryApiRequest<T> where TDto : BaseDto<T>
    {
        protected abstract string RequestedObjectName { get; }

        protected abstract Dictionary<string, string> GetIdsParams(DateTime date);

        protected ApiDiscoverRequestBase(IMovieDbSettings settings) : base(settings)
        {
        }

        public async Task<IEnumerable<T>> GetIds(DateTime date)
        {
            var param = GetIdsParams(date);

            var command = $"discover/{RequestedObjectName}";

            var totalPages = (await SearchAsync<TDto>(command, param));
            return (await Task.WhenAll(Enumerable.Range(1, totalPages.TotalPages).Select(x => GetIdsByPageNumber(command, x)))).SelectMany(x => x);
        }

        protected static async Task<IEnumerable<TObject>> GetFullObjectInfo<TObject, TId>(IDetailsApiRequest<TObject, TId> api,
            IEnumerable<TId> ids)
        {
            return (await Task.WhenAll(ids.Select(api.FindByIdAsync))).Select(x => x.Item);
        }

        private async Task<IEnumerable<T>> GetIdsByPageNumber(string command, int number)
        {
            var param = new Dictionary<string, string>
            {
                {"page", number.ToString()},
            };

            return (await SearchAsync<TDto>(command, param)).Results.Select(x => x.Id);
        }
    }
}