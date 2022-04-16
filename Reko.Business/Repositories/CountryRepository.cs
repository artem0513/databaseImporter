using Reko.Contracts.Repositories;
using Reko.Data;
using Reko.Data.Entities;
using Reko.Models.Dto;

namespace Reko.Business.Repositories
{
    public class CountryRepository : CRUDRepository<Country, CountryDto, RekoDbContext, string>, ICountryRepository
    {
        public CountryRepository(RekoDbContext context) : base(context)
        {
        }
    }
}