using System.Threading.Tasks;

namespace Reko.Contracts.ApiRequestFramework
{
    public interface IDetailsApiRequest<TObject, in TId>
    {
        Task<IApiQueryResponse<TObject>> FindByIdAsync(TId id);
    }
}