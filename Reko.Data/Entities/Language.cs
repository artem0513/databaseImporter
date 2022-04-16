using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Reko.Data.ProfileData;
using Reko.Models.Dto;

namespace Reko.Data.Entities
{
    public class Language : IMappableEntity<Language, LanguageDto, string>
    {
        [MaxLength(10)]
        public string Id { get; set; }

        [MaxLength(200)]
        public string Name { get; set; }

        public List<Movie> Movies { get; set; }

        public Language()
        {
            Movies = new List<Movie>();
        }

        public LanguageDto ToDto()
        {
            return RekoMapperProfile.Mapper.Map<LanguageDto>(this);
        }

        public Language FromDto(LanguageDto dto)
        {
            RekoMapperProfile.Mapper.Map(dto, this);
            return this;
        }
    }
}