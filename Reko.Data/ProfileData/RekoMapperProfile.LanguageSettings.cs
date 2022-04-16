using AutoMapper;
using Reko.Data.Entities;
using Reko.Models.Dto;

namespace Reko.Data.ProfileData
{
    public partial class RekoMapperProfile
    {
        private static void ConfigureLanguageFromDtoToEntity(IProfileExpression configuration)
        {
            configuration.CreateMap<LanguageDto, Language>().ForMember(x => x.Movies, x => x.Ignore());
        }

        private static void ConfigureLanguageFromEntityToDto(IProfileExpression configuration)
        {
            configuration.CreateMap<Language, LanguageDto>();
        }
    }
}
