using Reko.Contracts.Repositories;
using Reko.Data;
using Reko.Data.Entities;
using Reko.Models.Dto;

namespace Reko.Business.Repositories
{
    public class KeywordRepository : CRUDRepository<KeyWord, KeywordDto, RekoDbContext, int>, IKeywordRepository
    {
        public KeywordRepository(RekoDbContext context) : base(context)
        {
        }
    }
}