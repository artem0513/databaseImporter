using AutoMapper;
using Reko.Data.Entities;
using Reko.Models.Dto;

namespace Reko.Data.ProfileData
{
    public partial class RekoMapperProfile
    {
        private static void ConfigureProductionCompanyFromDtoToEntity(IProfileExpression configuration)
        {
            configuration.CreateMap<ProductionCompanyDto, ProductionCompany>().ForMember(x => x.Movies, x => x.Ignore())
                .ForMember(x => x.TvShows, x => x.Ignore());
        }

        private static void ConfigureProductionCompanyInfoFromEntityToDto(IProfileExpression configuration)
        {
            configuration.CreateMap<ProductionCompany, ProductionCompanyDto>().AfterMap((src, dst) =>
            {
                if (src.ParentCompanyLogoPath != null && src.ParentCompanyName != null)
                {
                    dst.ParentCompany = new ParentCompanyDto {LogoPath = src.ParentCompanyLogoPath, Name = src.ParentCompanyName};
                }
            });
        }
    }
}