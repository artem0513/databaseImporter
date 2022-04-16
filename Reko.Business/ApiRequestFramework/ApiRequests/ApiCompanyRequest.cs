using System.Collections.Generic;
using System.Threading.Tasks;
using Reko.Contracts.ApiRequestFramework;
using Reko.Models.Dto;

namespace Reko.Business.ApiRequestFramework.ApiRequests
{
    public sealed class ApiCompanyRequest : ApiRequestBase, IApiRequest, IDetailsApiRequest<ProductionCompanyDto, int>
    {
        private readonly IApiGenreRequest _genreApi;

        [ImportingConstructor]
        public ApiCompanyRequest(IMovieDbSettings settings, IApiGenreRequest genreApi)
            : base(settings)
        {
            _genreApi = genreApi;
        }

        public async Task<IApiQueryResponse<ProductionCompanyDto>> FindByIdAsync(int companyId)
        {
            var param = new Dictionary<string, string>
            {
                {"language", "he"},
            };

            var command = $"company/{companyId}";

            var response = await QueryAsync<ProductionCompanyDto>(command, param);

            return response;
        }
    }
}