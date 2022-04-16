using AutoMapper;
using Reko.Data.Entities;
using Reko.Models.Dto;

namespace Reko.Data.ProfileData
{
    public partial class RekoMapperProfile
    {
        private static void ConfigureCollectionInfoFromDtoToEntity(IProfileExpression configuration)
        {
            configuration.CreateMap<CollectionInfoDto, CollectionInfo>().ForMember(x => x.Movie, x => x.Ignore());
        }

        private static void ConfigureCollectionInfoFromEntityToDto(IProfileExpression configuration)
        {
            configuration.CreateMap<CollectionInfo, CollectionInfoDto>();
        }
    }
}
