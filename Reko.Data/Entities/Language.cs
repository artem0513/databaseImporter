using System.Collections.Generic;
using Reko.Data.ProfileData;
using Reko.Models.Dto;

namespace Reko.Data.Entities
{
    public class Language : IMappableEntity<Language, LanguageDto, string>
    {
        public string Id { get; set; }
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