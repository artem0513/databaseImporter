using System;
using Reko.Data.ProfileData;
using Reko.Models.Dto;
using Reko.Models.Enums;

namespace Reko.Data.Entities
{
    public class Person : IMappableEntity<Person, PersonDto, int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AlsoKnownAs { get; set; }
        public bool IsAdultFilmStar { get; set; }
        public string Biography { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime? Deathday { get; set; }
        public Gender? Gender { get; set; }
        public string Homepage { get; set; }
        public string ImdbId { get; set; }
        public string PlaceOfBirth { get; set; }
        public double Popularity { get; set; }
        public string ProfilePath { get; set; }



        public PersonDto ToDto()
        {
            return RekoMapperProfile.Mapper.Map<PersonDto>(this);
        }

        public Person FromDto(PersonDto dto)
        {
            RekoMapperProfile.Mapper.Map(dto, this);
            return this;
        }
    }
}