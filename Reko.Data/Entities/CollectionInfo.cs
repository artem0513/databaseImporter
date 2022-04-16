using Reko.Data.ProfileData;
using Reko.Models.Dto;

namespace Reko.Data.Entities
{
    public sealed class CollectionInfo : IMappableEntity<CollectionInfo, CollectionInfoDto, int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string HeName { get; set; }
        public string PosterPath { get; set; }
        public string BackdropPath { get; set; }
        public Movie Movie { get; set; }

        public CollectionInfoDto ToDto()
        {
            return RekoMapperProfile.Mapper.Map<CollectionInfoDto>(this);
        }

        public CollectionInfo FromDto(CollectionInfoDto dto)
        {
            RekoMapperProfile.Mapper.Map(dto, this);
            return this;
        }
    }
}