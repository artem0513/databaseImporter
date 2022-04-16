using Reko.Contracts.Repositories;
using Reko.Data;
using Reko.Data.Entities;
using Reko.Models.Dto;

namespace Reko.Business.Repositories
{
    public class EpisodeRepository : CRUDRepository<Episode, EpisodeDto, RekoDbContext, int>, IEpisodeRepository
    {
        public EpisodeRepository(RekoDbContext context) : base(context)
        {
        }
    }
}