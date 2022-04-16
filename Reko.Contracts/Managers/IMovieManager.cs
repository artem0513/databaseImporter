using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Reko.Data.Entities;
using Reko.Models.Dto;

namespace Reko.Contracts.Managers
{
    public interface IMovieManager : ICRUDManager<Movie, MovieDto, int>
    {
        Task<MovieDto> GetMovieInfo(int id, CancellationToken cancellationToken);
    }
}