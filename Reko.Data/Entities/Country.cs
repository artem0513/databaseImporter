using System.Collections.Generic;
using Reko.Data.ProfileData;
using Reko.Models.Dto;

namespace Reko.Data.Entities
{
    public sealed class Country : IMappableEntity<Country, CountryDto, string>
    {
        public string Id { get; set; }
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