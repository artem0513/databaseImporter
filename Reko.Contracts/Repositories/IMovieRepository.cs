using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Reko.Contracts.Containers;
using Reko.Data.Entities;
using Reko.Models.Dto;

namespace Reko.Contracts.Repositories
{
    public interface IMovieRepository : ILinkRepository<IUniqueMovieDataContainer, MovieDto, int>
    {
        Task<MovieDto> GetMovie(int id, CancellationToken cancellationToken);
        Task AddCollectionInfos(IEnumerable<CollectionInfoDto> collectionInfos, CancellationToken cancellationToken);
    }
}