using Reko.Contracts.Repositories;
using Reko.Data;
using Reko.Data.Entities;
using Reko.Models.Dto;

namespace Reko.Business.Repositories
{
    public class NetworkRepository : CRUDRepository<Network, NetworkDto, RekoDbContext, int>, INetworkRepository
    {
        public NetworkRepository(RekoDbContext context) : base(context)
        {
        }
    }
}