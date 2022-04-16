using Reko.Contracts.Repositories;
using Reko.Data;
using Reko.Data.Entities;
using Reko.Models.Dto;

namespace Reko.Business.Repositories
{
    public class TvShowCreatorRepository : CRUDRepository<TvShowCreator, TVShowCreatorDto, RekoDbContext, int>, ITvShowCreatorRepository
    {
        public TvShowCreatorRepository(RekoDbContext context) : base(context)
        {
        }
    }
}