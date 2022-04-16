using System;
using System.Collections.Generic;
using Reko.Data.ProfileData;
using Reko.Models.Dto;

namespace Reko.Data.Entities
{
    public class Season : IMappableEntity<Season, SeasonDto, int>
    {
        public int Id { get; set; }
        public DateTime AirDate { get; set; }
        public string PosterPath { get; set; }
        public string Name { get; set; }
        public string HeName { get; set; }
        public string Overview { get; set; }
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