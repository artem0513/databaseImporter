using System.Threading.Tasks;
using Reko.Models.Dto;

namespace Reko.Contracts.Repositories
{
    public interface IMovieRepository : ICRUDRepository<MovieDto,int>, ILinkRepository<MovieDto>
    {
        Task<MovieDto> GetMovie(int id);
    }
}