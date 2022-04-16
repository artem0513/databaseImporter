using System.Collections.Generic;

namespace Reko.Contracts.ApiRequestFramework
{
    public interface IApiSearchResponse<T>
    {
        public IEnumerable<T> Results { get; }

        public int PageNumber { get; }

        public int TotalPages { get; }

        public int TotalResults { get; }
    }
}