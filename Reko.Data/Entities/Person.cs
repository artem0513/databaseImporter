using System;
using System.ComponentModel.DataAnnotations;
using Reko.Data.ProfileData;
using Reko.Models.Dto;
using Reko.Models.Enums;

namespace Reko.Data.Entities
{
    public class Person : IMappableEntity<Person, PersonDto, int>
    {
        public int Id { get; set; }

        [MaxLength(1200)]
        public string Name { get; set; }

        [MaxLength(5000)]
        public string AlsoKnownAs { get; set; }

        public bool IsAdultFilmStar { get; set; }

        [MaxLength(6000)]
        public string Biography { get; set; }

        public DateTime Birthday { get; set; }
        public DateTime? Deathday { get; set; }
        public Gender? Gender { get; set; }

        [MaxLength(2048)]
        public string Homepage { get; set; }

        [MaxLength(200)]
        public string ImdbId { get; set; }

        [MaxLength(300)]
        public string PlaceOfBirth { get; set; }

        public double Popularity { get; set; }

        [MaxLength(2048)]
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