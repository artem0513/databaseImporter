namespace Reko.Contracts.ApiRequestFramework
{
    public interface IApiCatalogRequest<TObject, TId> : IDetailsApiRequest<TObject, TId>, IDiscoveryApiRequest<TId>
    {
    }
}