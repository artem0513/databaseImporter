using Reko.Models.Enums;

namespace Reko.Contracts.ApiRequestFramework
{
    public interface IApiError
    {
        public int StatusCode { get; }

        public string Message { get; }

        public TmdbStatusCode TmdbStatusCode { get; }
    }
}