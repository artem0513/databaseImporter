using AutoMapper;
using Reko.Data.Entities;
using Reko.Models.Dto;

namespace Reko.Data.ProfileData
{
    public partial class RekoMapperProfile
    {
        private static void ConfigureGuestStarFromDtoToEntity(IProfileExpression configuration)
        {
            configuration.CreateMap<GuestStarDto, GuestStar>().ForMember(x => x.Episodes, x=>x.Ignore());
        }

        private static void ConfigureGuestStarFromEntityToDto(IProfileExpression configuration)
        {
            configuration.CreateMap<GuestStar, GuestStarDto>();
        }
    }
}
