using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [MaxLength(1200)]
        public string Name { get; set; }

        [MaxLength(1200)]
        public string HeName { get; set; }

        [MaxLength(2048)]
        public string StillPath { get; set; }

        [MaxLength(6000)]
        public string Overview { get; set; }

        [MaxLength(6000)]
        public string HeOverview { get; set; }

        [MaxLength(2048)]
        public string PosterPath { get; set; }

        [MaxLength(300)]
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