namespace Reko.Contracts.ApiRequestFramework
{
    public interface IApiResponse
    {
        public IApiError Error { get; set; }

        public string CommandText { get; set; }

        public string Json { get; set; }
    }
}