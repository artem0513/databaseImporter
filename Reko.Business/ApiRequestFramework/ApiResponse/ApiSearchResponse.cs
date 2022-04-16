using System.Collections.Generic;
using System.Runtime.Serialization;
using Reko.Contracts.ApiRequestFramework;

namespace Reko.Business.ApiRequestFramework.ApiResponse
{
    [DataContract]
    public class ApiSearchResponse<T> : ApiResponseBase, IApiSearchResponse<T>
    {
        [DataMember(Name = "results")]
        public IEnumerable<T> Results { get; private set; }

        [DataMember(Name = "page")]
        public int PageNumber { get; private set; }

        [DataMember(Name = "total_pages")]
        public int TotalPages { get; private set; }

        [DataMember(Name = "total_results")]
        public int TotalResults { get; private set; }

        public override string ToString()
            => $"Page {PageNumber} of {TotalPages} ({TotalResults} total results)";
    }
}