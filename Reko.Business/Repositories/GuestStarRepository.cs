using Reko.Contracts.Repositories;
using Reko.Data;
using Reko.Data.Entities;
using Reko.Models.Dto;

namespace Reko.Business.Repositories
{
    public class GuestStarRepository : CRUDRepository<GuestStar, GuestStarDto, RekoDbContext, int>, IGuestStarRepository
    {
        public GuestStarRepository(RekoDbContext context) : base(context)
        {
        }
    }
}