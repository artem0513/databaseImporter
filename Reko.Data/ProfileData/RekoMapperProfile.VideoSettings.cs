using AutoMapper;
using Reko.Data.Entities;
using Reko.Models.Dto;

namespace Reko.Data.ProfileData
{
    public partial class RekoMapperProfile
    {
        private static void ConfigureVideoFromDtoToEntity(IProfileExpression configuration)
        {
            configuration.CreateMap<VideoDto, Video>();
        }

        private static void ConfigureVideoFromEntityToDto(IProfileExpression configuration)
        {
            configuration.CreateMap<Video, VideoDto>();
        }
    }
}
