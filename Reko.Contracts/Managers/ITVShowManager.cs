using System.Collections.Generic;
using System.Threading.Tasks;
using Reko.Models.Dto;

namespace Reko.Contracts.Managers
{
    public interface ITVShowManager
    {
        Task<IEnumerable<TVShowDto>> GetTvShows();
        Task<TVShowDto> GetTvShowInfo(int id);
    }
}