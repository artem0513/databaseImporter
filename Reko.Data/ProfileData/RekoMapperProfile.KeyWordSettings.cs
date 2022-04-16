using AutoMapper;
using Reko.Data.Entities;
using Reko.Models.Dto;

namespace Reko.Data.ProfileData
{
    public partial class RekoMapperProfile
    {
        private static void ConfigureKeyWordFromDtoToEntity(IProfileExpression configuration)
        {
            configuration.CreateMap<KeywordDto, KeyWord>().ForMember(x => x.TvShows, x => x.Ignore()).ForMember(x => x.Movies, x => x.Ignore());
        }

        private static void ConfigureKeyWordFromEntityToDto(IProfileExpression configuration)
        {
            configuration.CreateMap<KeyWord, KeywordDto>();
        }
    }
}
