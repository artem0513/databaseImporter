using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Reko.Data.Entities;
using Reko.Models.Dto;

namespace Reko.Data.ProfileData
{
    public partial class RekoMapperProfile
    {
        private static void ConfigureSeasonFromDtoToEntity(IProfileExpression configuration)
        {
            configuration.CreateMap<SeasonDto, Season>().ForMember(x => x.TvShow, x => x.Ignore()).ForMember(x => x.Episodes, x => x.Ignore());
        }

        private static void ConfigureSeasonFromEntityToDto(IProfileExpression configuration)
        {
            configuration.CreateMap<Season, SeasonDto>().ForMember(x => x.Episodes, x => x.Ignore()).AfterMap((src, dst) =>
            {
                dst.Episodes = Mapper.Map<IEnumerable<EpisodeDto>>(src.Episodes ?? new List<Episode>());
            });
        }
    }
}