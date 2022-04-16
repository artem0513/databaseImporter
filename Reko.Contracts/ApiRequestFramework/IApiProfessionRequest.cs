using System.Collections.Generic;
using System.Threading.Tasks;
using Reko.Models.Dto;

namespace Reko.Contracts.ApiRequestFramework
{
    public interface IApiProfessionRequest : IApiRequest
    {
        Task<IApiQueryResponse<IEnumerable<ProfessionDto>>> GetAllAsync();
    }
}