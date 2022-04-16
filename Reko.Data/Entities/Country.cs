using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Reko.Data.ProfileData;
using Reko.Models.Dto;

namespace Reko.Data.Entities
{
    public sealed class Country : IMappableEntity<Country, CountryDto, string>
    {
        [MaxLength(10)]
        public string Id { get; set; }

        [MaxLength(300)]
        public string Name { get; set; }

        public List<Movie> Movies { get; set; }

        public Country()
        {
            Movies = new List<Movie>();
        }

        public CountryDto ToDto()
        {
            return RekoMapperProfile.Mapper.Map<CountryDto>(this);
        }

        public Country FromDto(CountryDto dto)
        {
            RekoMapperProfile.Mapper.Map(dto, this);
            return this;
        }
    }
}