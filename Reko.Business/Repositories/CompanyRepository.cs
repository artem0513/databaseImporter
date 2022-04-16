using Reko.Contracts.Repositories;
using Reko.Data;
using Reko.Data.Entities;
using Reko.Models.Dto;

namespace Reko.Business.Repositories
{
    public sealed class CompanyRepository : CRUDRepository<ProductionCompany, ProductionCompanyDto, RekoDbContext, int>, ICompanyRepository
    {
        public CompanyRepository(RekoDbContext context) : base(context)
        {
        }
    }
}