using AutoMapper;
using Reko.Data.Entities;
using Reko.Models.Dto;

namespace Reko.Data.ProfileData
{
    public partial class RekoMapperProfile
    {
        private static void ConfigureCastMemberFromDtoToEntity(IProfileExpression configuration)
        {
            configuration.CreateMap<CastMemberDto, CastMember>().ForMember(x => x.Movies, x => x.Ignore());
        }

        private static void ConfigureCastMemberFromEntityToDto(IProfileExpression configuration)
        {
            configuration.CreateMap<CastMember, CastMemberDto>();
        }
    }
}
