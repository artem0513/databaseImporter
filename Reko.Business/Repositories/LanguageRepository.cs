using Reko.Contracts.Repositories;
using Reko.Data;
using Reko.Data.Entities;
using Reko.Models.Dto;

namespace Reko.Business.Repositories
{
    public class LanguageRepository : CRUDRepository<Language, LanguageDto, RekoDbContext, string>, ILanguageRepository
    {
        public LanguageRepository(RekoDbContext context) : base(context)
        {
        }
    }
}