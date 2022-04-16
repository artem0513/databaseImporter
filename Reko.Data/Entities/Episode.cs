using System;
using System.Collections.Generic;
using Reko.Data.ProfileData;
using Reko.Models.Dto;

namespace Reko.Data.Entities
{
    public class Episode : IMappableEntity<Episode, EpisodeDto, int>
    {
        public int Id { get; set; }
        public DateTime? AidDate { get; set; }
        public int EpisodeNumber { get; set; }
        public int VoteCount { get; set; }
        public int SeasonNumber { get; set; }
        public double VoteAverage { get; set; } 
        public string Name { get; set; }
        public string HeName { get; set; }
        public string StillPath { get; set; }
        public string Overview { get; set; }
        public string HeOverview { get; set; }
        public string PosterPath { get; set; }
        public string ProductionCode { get; set; }
        public int? SeasonId { get; set; }
        public Season Season { get; set; }
        public List<CrewMember> CrewMembers { get; set; }
        public List<GuestStar> GuestStars { get; set; }

        public Episode()
        {
            CrewMembers = new List<CrewMember>();
            GuestStars = new List<GuestStar>();
        }

        public EpisodeDto ToDto()
        {
            return RekoMapperProfile.Mapper.Map<EpisodeDto>(this);
        }

        public Episode FromDto(EpisodeDto dto)
        {
            RekoMapperProfile.Mapper.Map(dto, this);
            return this;
        }
    }
}