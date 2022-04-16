using System.Collections.Generic;
using System.Threading.Tasks;
using Reko.Models.Dto;

namespace Reko.Contracts.Managers
{
    public interface IMovieManager
    {
        Task<IEnumerable<MovieDto>> GetMovies();
        Task<MovieDto> GetMovieInfo(int id);
    }
}