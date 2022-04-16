using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Reko.Contracts.ApiRequestFramework;
using Reko.Models.Dto;

namespace Reko.Business.ApiRequestFramework.ApiRequests
{
    public class ApiProfessionRequest : ApiRequestBase, IApiProfessionRequest
    {
        [ImportingConstructor]
        public ApiProfessionRequest(IMovieDbSettings settings)
            : base(settings)
        {
        }

        public async Task<IApiQueryResponse<IEnumerable<ProfessionDto>>> GetAllAsync()
        {
            const string command = "job/list";

            var response = await QueryAsync(command, ProfessionDeserializer);

            return response;
        }

        private static IEnumerable<ProfessionDto> ProfessionDeserializer(string json)
        {
            var obj = JObject.Parse(json);

            var arr = (JArray) obj["jobs"];

            var professions = arr.ToObject<IReadOnlyList<ProfessionDto>>();

            return professions;
        }
    }
}