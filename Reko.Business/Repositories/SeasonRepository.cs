using Reko.Contracts.Repositories;
using Reko.Data;
using Reko.Data.Entities;
using Reko.Models.Dto;

namespace Reko.Business.Repositories
{
    public class SeasonRepository : CRUDRepository<Season, SeasonDto, RekoDbContext, int>, ISeasonRepository
    {
        public SeasonRepository(RekoDbContext context) : base(context)
        {
        }
    }
}