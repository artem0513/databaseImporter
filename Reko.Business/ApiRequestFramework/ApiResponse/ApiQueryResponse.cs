using Reko.Contracts.ApiRequestFramework;

namespace Reko.Business.ApiRequestFramework.ApiResponse
{
    public class ApiQueryResponse<T> : ApiResponseBase, IApiQueryResponse<T>
    {
        public T Item { get; set; }

        public override string ToString() => Item.ToString();
    }
}