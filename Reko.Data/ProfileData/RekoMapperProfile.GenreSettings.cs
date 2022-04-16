using AutoMapper;
using Reko.Data.Entities;
using Reko.Models.Dto;

namespace Reko.Data.ProfileData
{
    public partial class RekoMapperProfile
    {
        private static void ConfigureGenreFromDtoToEntity(IProfileExpression configuration)
        {
            configuration.CreateMap<GenreDto, Genre>().ForMember(x => x.Movies, x => x.Ignore()).ForMember(x => x.TvShows, x => x.Ignore());
        }

        private static void ConfigureGenreFromEntityToDto(IProfileExpression configuration)
        {
            configuration.CreateMap<Genre, GenreDto>();
        }
    }
}