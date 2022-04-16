using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Reko.Data.ProfileData;
using Reko.Models.Dto;

namespace Reko.Data.Entities
{
    public class Season : IMappableEntity<Season, SeasonDto, int>
    {
        public int Id { get; set; }
        public DateTime AirDate { get; set; }

        [MaxLength(2048)]
        public string PosterPath { get; set; }

        [MaxLength(1200)]
        public string Name { get; set; }

        [MaxLength(1200)]
        public string HeName { get; set; }

        [MaxLength(6000)]
        public string Overview { get; set; }

        [MaxLength(6000)]
        public string HeOverview { get; set; }

        public int SeasonNumber { get; set; }
        public int? TvShowId { get; set; }
        public TvShow TvShow { get; set; }
        public List<Episode> Episodes { get; set; }

        public Season()
        {
            Episodes = new List<Episode>();
        }

        public SeasonDto ToDto()
        {
            return RekoMapperProfile.Mapper.Map<SeasonDto>(this);
        }

        public Season FromDto(SeasonDto dto)
        {
            RekoMapperProfile.Mapper.Map(dto, this);
            return this;
        }
    }
}