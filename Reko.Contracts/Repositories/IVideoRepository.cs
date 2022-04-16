using Reko.Data.Entities;
using Reko.Models.Dto;

namespace Reko.Contracts.Repositories
{
    public interface IVideoRepository : ICRUDRepository<VideoDto, string>
    {
        
    }
}