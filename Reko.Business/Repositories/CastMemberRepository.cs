using Reko.Contracts.Repositories;
using Reko.Data;
using Reko.Data.Entities;
using Reko.Models.Dto;

namespace Reko.Business.Repositories
{
    public class CastMemberRepository : CRUDRepository<CastMember, CastMemberDto, RekoDbContext, int>, ICastMemberRepository
    {
        public CastMemberRepository(RekoDbContext context) : base(context)
        {
        }
    }
}