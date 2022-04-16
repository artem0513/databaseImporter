using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reko.Contracts.ApiRequestFramework;
using Reko.Models.Dto;

namespace Reko.Business.ApiRequestFramework.ApiRequests
{
    public sealed class ApiMovieRequest : ApiDiscoverRequestBase<MovieDto, int>, IApiRequest, IApiCatalogRequest<MovieDto, int>
    {
        private readonly IApiGenreRequest _genreApi;
        protected override string RequestedObjectName { get; } = "movie";

        [ImportingConstructor]
        public ApiMovieRequest(IMovieDbSettings settings, IApiGenreRequest genreApi)
            : base(settings)
        {
            _genreApi = genreApi;
        }

        public async Task<IApiQueryResponse<MovieDto>> FindByIdAsync(int movieId)
        {
            var param = new Dictionary<string, string>
            {
                {"language", "en"},
                {"append_to_response", "keywords,credits,videos"},
            };

            var command = $"movie/{movieId}";

            var response = await QueryAsync<MovieDto>(command, param);
            param["language"] = "he";
            var heResponse = await QueryAsync<MovieDto>(command, param);
            response.Item.HeTitle = heResponse.Item.Title;
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

            if (response.Item.MovieCollectionInfo != null)
            {
                response.Item.MovieCollectionInfo.HeName = heResponse.Item.MovieCollectionInfo.Name;
            }

            return response;
        }

        protected override Dictionary<string, string> GetIdsParams(DateTime date)
        {
            var dateToString = date.ToString("yyyy-MM-dd");
            return new Dictionary<string, string>
            {
                {"primary_release_date.gte", dateToString},
                {"primary_release_date.lte", dateToString},
            };
        }
    }
}