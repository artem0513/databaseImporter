using Reko.Models.Dto;

namespace Reko.Contracts.Repositories
{
    public interface ICompanyRepository : ICRUDRepository<ProductionCompanyDto, int>
    {
    }
}