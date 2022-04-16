using AutoMapper;
using Reko.Data.Entities;
using Reko.Models.Dto;

namespace Reko.Data.ProfileData
{
    public partial class RekoMapperProfile
    {
        private static void ConfigureCrewMemberFromDtoToEntity(IProfileExpression configuration)
        {
            configuration.CreateMap<CrewMemberDto, CrewMember>().ForMember(x => x.Movies, x => x.Ignore());
        }

        private static void ConfigureCrewMemberFromEntityToDto(IProfileExpression configuration)
        {
            configuration.CreateMap<CrewMember, CrewMemberDto>();
        }
    }
}
