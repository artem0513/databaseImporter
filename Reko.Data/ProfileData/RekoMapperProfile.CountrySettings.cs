using AutoMapper;
using Reko.Data.Entities;
using Reko.Models.Dto;

namespace Reko.Data.ProfileData
{
    public partial class RekoMapperProfile
    {
        private static void ConfigureCountryFromDtoToEntity(IProfileExpression configuration)
        {
            configuration.CreateMap<CountryDto, Country>().ForMember(x => x.Movies, x => x.Ignore());
        }

        private static void ConfigureCountryFromEntityToDto(IProfileExpression configuration)
        {
            configuration.CreateMap<Country, CountryDto>();
        }
    }
}
