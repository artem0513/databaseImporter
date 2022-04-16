using Reko.Models.Dto;

namespace Reko.Contracts.Repositories
{
    public interface ICountryRepository : ICRUDRepository<CountryDto, string>
    {
        
    }
}