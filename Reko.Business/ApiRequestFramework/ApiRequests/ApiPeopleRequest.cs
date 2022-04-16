using System.Collections.Generic;
using System.Threading.Tasks;
using Reko.Contracts.ApiRequestFramework;
using Reko.Models.Dto;

namespace Reko.Business.ApiRequestFramework.ApiRequests
{
    public class ApiPeopleRequest : ApiRequestBase, IApiRequest, IDetailsApiRequest<PersonDto, int>
    {
        private readonly IApiGenreRequest _genreApi;

        [ImportingConstructor]
        public ApiPeopleRequest(IMovieDbSettings settings, IApiGenreRequest genreApi)
            : base(settings)
        {
            _genreApi = genreApi;
        }

        public async Task<IApiQueryResponse<PersonDto>> FindByIdAsync(int personId)
        {
            var param = new Dictionary<string, string>
            {
                {"language", "en"}
            };

            var command = $"person/{personId}";

            var response = await QueryAsync<PersonDto>(command, param);

            return response;
        }
    }
}