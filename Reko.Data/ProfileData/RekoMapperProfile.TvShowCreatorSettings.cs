using AutoMapper;
using Reko.Data.Entities;
using Reko.Models.Dto;

namespace Reko.Data.ProfileData
{
    public partial class RekoMapperProfile
    {
        private static void ConfigureTVShowCreatorFromDtoToEntity(IProfileExpression configuration)
        {
            configuration.CreateMap<TVShowCreatorDto, TvShowCreator>().ForMember(x => x.TvShows, x => x.Ignore());
        }

        private static void ConfigureTVShowCreatorFromEntityToDto(IProfileExpression configuration)
        {
            configuration.CreateMap<TvShowCreator, TVShowCreatorDto>();
        }
    }
}
