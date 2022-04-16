using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reko.Contracts.ApiRequestFramework;
using Reko.Models.Dto;

namespace Reko.Business.ApiRequestFramework.ApiRequests
{
    public class ApiSeasonRequest : ApiRequestBase, IApiRequest, IDetailsApiRequest<SeasonDto, int>
    {
        private readonly IApiGenreRequest _genreApi;
        private int? tvId;

        [ImportingConstructor]
        public ApiSeasonRequest(IMovieDbSettings settings, IApiGenreRequest genreApi)
            : base(settings)
        {
            _genreApi = genreApi;
        }

        public async Task<IApiQueryResponse<SeasonDto>> FindByIdAsync(int seasonNumber)
        {
            if (!tvId.HasValue)
            {
                throw new Exception("Tv id should be configured before using season api.");
            }

            var param = new Dictionary<string, string>
            {
                {"language", "en"},
            };

            var command = $"tv/{tvId}/season/{seasonNumber}";

            var response = await QueryAsync<SeasonDto>(command, param);

            param["language"] = "he";

            var heResponse = await QueryAsync<SeasonDto>(command, param);

            response.Item.HeName = heResponse.Item.Name;
            response.Item.HeOverview = heResponse.Item.Overview;
            response.Item.Episodes = response.Item.Episodes.Join(heResponse.Item.Episodes, x => x.Id, x => x.Id, (en, he) =>
            {
                en.HeName = he.Name;
                en.HeOverview = he.Overview;
                return en;
            });

            return response;
        }

        public void SetTvId(int id)
        {
            tvId = id;
        }
    }
}