using Reko.Contracts.Repositories;
using Reko.Data;
using Reko.Data.Entities;
using Reko.Models.Dto;

namespace Reko.Business.Repositories
{
    public class CrewMemberRepository : CRUDRepository<CrewMember, CrewMemberDto, RekoDbContext, int>, ICrewMemberRepository
    {
        public CrewMemberRepository(RekoDbContext context) : base(context)
        {
        }
    }
}