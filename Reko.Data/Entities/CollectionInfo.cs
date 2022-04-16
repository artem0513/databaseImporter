using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Reko.Data.ProfileData;
using Reko.Models.Dto;

namespace Reko.Data.Entities
{
    public sealed class CollectionInfo : IMappableEntity<CollectionInfo, CollectionInfoDto, int>
    {
        public int Id { get; set; }

        [MaxLength(1200)]
        public string Name { get; set; }

        [MaxLength(1200)]
        public string HeName { get; set; }

        [MaxLength(2048)]
        public string PosterPath { get; set; }

        [MaxLength(2048)]
        public string BackdropPath { get; set; }

        public List<Movie> Movies { get; set; }

        public CollectionInfo()
        {
            Movies = new List<Movie>();
        }

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