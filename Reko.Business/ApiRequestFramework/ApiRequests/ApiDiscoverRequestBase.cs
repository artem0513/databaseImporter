using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reko.Contracts.ApiRequestFramework;
using Reko.Models.Dto;

namespace Reko.Business.ApiRequestFramework.ApiRequests
{
    public abstract class ApiDiscoverRequestBase<TDto, TId> : ApiRequestBase, IDiscoveryApiRequest<TId> where TDto : BaseDto<TId>
    {
        protected abstract string RequestedObjectName { get; }

        protected abstract Dictionary<string, string> GetIdsParams(DateTime from, DateTime to);

        protected ApiDiscoverRequestBase(IMovieDbSettings settings) : base(settings)
        {
        }

        public async Task<IEnumerable<TId>> GetIds(DateTime from, DateTime to)
        {
            var param = GetIdsParams(from, to);

            var command = $"discover/{RequestedObjectName}";

            var totalPages = await SearchAsync<TDto>(command, param);
            return (await Task.WhenAll(Enumerable.Range(1, totalPages.TotalPages).Select(x => GetIdsByPageNumber(command, from, to, x)))).SelectMany(x => x)
                .Distinct();
        }

        protected static async Task<IEnumerable<TObject>> GetFullObjectInfo<TObject>(IDetailsApiRequest<TObject, TId> api,
            IEnumerable<TId> ids)
        {
            if (api == null) throw new ArgumentNullException(nameof(api));

            if (ids == null) throw new ArgumentNullException(nameof(ids));

            return (await Task.WhenAll(ids.Select(api.FindByIdAsync))).Select(x => x.Item).Where(x => x != null);
        }

        private async Task<IEnumerable<TId>> GetIdsByPageNumber(string command, DateTime from, DateTime to, int number)
        {
            var param = GetIdsParams(from, to);
            param.Add("page", number.ToString());

            return (await SearchAsync<TDto>(command, param)).Results.Select(x => x.Id);
        }
    }
}