using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Reko.Data.Entities;
using Reko.Models.Dto;

namespace Reko.Contracts.Managers
{
    public interface ITVShowManager : ICRUDManager<TvShow, TVShowDto, int>
    {
        Task<TVShowDto> GetTvShowInfo(int id, CancellationToken cancellationToken);
    }
}