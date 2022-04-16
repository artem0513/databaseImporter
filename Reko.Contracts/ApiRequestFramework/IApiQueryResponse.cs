namespace Reko.Contracts.ApiRequestFramework
{
    public interface IApiQueryResponse<T> : IApiResponse
    {
        public T Item { get; set; }
    }
}