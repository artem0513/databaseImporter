using Reko.Contracts.ApiRequestFramework;

namespace Reko.Business.ApiRequestFramework.ApiResponse
{
    public abstract class ApiResponseBase : IApiResponse
    {
        public IApiError Error { get; set; }

        public string CommandText { get; set; }

        public string Json { get; set; }

        public override string ToString()
            => CommandText;
    }
}