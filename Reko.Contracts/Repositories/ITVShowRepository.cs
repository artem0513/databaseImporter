using System.Collections.Generic;
using System.Threading.Tasks;
using Reko.Models.Dto;

namespace Reko.Contracts.Repositories
{
    public interface ITVShowRepository : ICRUDRepository<TVShowDto, int>, ILinkRepository<TVShowDto>
    {
        Task<TVShowDto> GetTvShowInfo(int id);
    }
}