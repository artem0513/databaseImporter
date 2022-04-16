using System.Threading;
using System.Threading.Tasks;
using Reko.Contracts.Containers;
using Reko.Models.Dto;

namespace Reko.Contracts.Repositories
{
    public interface ITVShowRepository : ILinkRepository<IUniqueTvShowDataContainer, TVShowDto, int>
    {
        Task<TVShowDto> GetTvShowInfo(int id, CancellationToken cancellationToken);
    }
}