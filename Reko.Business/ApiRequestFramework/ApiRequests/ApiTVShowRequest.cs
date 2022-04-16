using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reko.Business.ApiRequestFramework.ApiResponse;
using Reko.Contracts.ApiRequestFramework;
using Reko.Models.Dto;

namespace Reko.Business.ApiRequestFramework.ApiRequests
{
    public sealed class ApiTVShowRequest : ApiDiscoverRequestBase<TVShowDto, int>, IApiRequest, IApiCatalogRequest<TVShowDto, int>
    {
        private readonly IApiGenreRequest _genreApi;
        protected override string RequestedObjectName { get; } = "tv";

        [ImportingConstructor]
        public ApiTVShowRequest(IMovieDbSettings settings, IApiGenreRequest genreApi)
            : base(settings)
        {
            _genreApi = genreApi;
        }

        public async Task<IApiQueryResponse<TVShowDto>> FindByIdAsync(int tvShowId)
        {
            var param = new Dictionary<string, string>
            {
                {"language", "en"},
                {"append_to_response", "keywords,credits,videos"}
            };

            var command = $"tv/{tvShowId}";

            var response = await QueryAsync<TVShowDto>(command, param);

            param["language"] = "he";

            var heResponse = await QueryAsync<TVShowDto>(command, param);

            if (heResponse.Item != null && response.Item != null)
            {
                await SetHebrewLanguage(response, heResponse, tvShowId);
                return response;
            }

            return null;
        }

        protected override Dictionary<string, string> GetIdsParams(DateTime from, DateTime to)
        {
            return new Dictionary<string, string>
            {
                {"first_air_date.gte", from.ToString("yyyy-MM-dd")},
                {"first_air_date.lte", to.ToString("yyyy-MM-dd")},
            };
        }

        private static async Task SetHebrewLanguage(IApiQueryResponse<TVShowDto> response, IApiQueryResponse<TVShowDto> heResponse, int tvShowId)
        {
            response.Item.HeName = heResponse.Item.Name;
            response.Item.HeOverview = heResponse.Item.Overview;
            response.Item.Videos.Videos = response.Item.Videos?.Videos.Concat(heResponse.Item.Videos?.Videos ?? Enumerable.Empty<VideoDto>())
                .Where(x => x != null);
            response.Item.Genres = response.Item.Genres.Join(heResponse.Item.Genres, x => x.Id, x => x.Id, (en, he) =>
            {
                en.HeName = he.Name;
                return en;
            });
            response.Item.ProductionCompanies = (await GetFullObjectInfo(MovieDbFactory.Create<ApiCompanyRequest>().Value,
                response.Item.ProductionCompanies.Select(x => x.Id))).Where(x => x != null);
            var seasonApi = MovieDbFactory.Create<ApiSeasonRequest>().Value;
            seasonApi.SetTvId(tvShowId);
            response.Item.Seasons =
                (await GetFullObjectInfo(seasonApi, response.Item.Seasons.Select(x => x.SeasonNumber)))
                .Where(x => x != null);
        }
    }
}