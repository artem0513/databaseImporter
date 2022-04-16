using AutoMapper;
using Reko.Data.Entities;
using Reko.Models.Dto;

namespace Reko.Data.ProfileData
{
    public partial class RekoMapperProfile
    {
        private static void ConfigureNetworkFromDtoToEntity(IProfileExpression configuration)
        {
            configuration.CreateMap<NetworkDto, Network>().ForMember(x => x.TvShows, x => x.Ignore());
        }

        private static void ConfigureNetworkFromEntityToDto(IProfileExpression configuration)
        {
            configuration.CreateMap<Network, NetworkDto>();
        }
    }
}
