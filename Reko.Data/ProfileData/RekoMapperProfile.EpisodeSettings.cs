using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Reko.Data.Entities;
using Reko.Models.Dto;

namespace Reko.Data.ProfileData
{
    public partial class RekoMapperProfile
    {
        private static void ConfigureEpisodeFromDtoToEntity(IProfileExpression configuration)
        {
            configuration.CreateMap<EpisodeDto, Episode>().ForMember(x => x.Season, x => x.Ignore()).ForMember(x => x.CrewMembers, x => x.Ignore())
                .ForMember(x => x.GuestStars, x => x.Ignore()).ForMember(x => x.Season, x => x.Ignore());
        }

        private static void ConfigureEpisodeFromEntityToDto(IProfileExpression configuration)
        {
            configuration.CreateMap<Episode, EpisodeDto>().ForMember(x => x.CrewMembers, x => x.Ignore())
                .ForMember(x => x.GuestStars, x => x.Ignore())
                .AfterMap((src, dst) =>
                {
                    dst.CrewMembers = Mapper.Map<ICollection<CrewMemberDto>>(src.CrewMembers ?? new List<CrewMember>());
                    dst.GuestStars = Mapper.Map<ICollection<GuestStarDto>>(src.GuestStars ?? new List<GuestStar>());
                });
        }
    }
}