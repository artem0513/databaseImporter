using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Reko.Models.Dto
{
    public class EpisodeDto : BaseDto<int>
    {
        [DataMember(Name = "ait_date")]
        public DateTime AidDate { get; set; }

        [DataMember(Name = "crew")]
        public IEnumerable<CrewMemberDto> CrewMembers { get; set; }

        [DataMember(Name = "guest_stars")]
        public IEnumerable<GuestStarDto> GuestStars { get; set; }

        [DataMember(Name = "episode_number")]
        public int EpisodeNumber { get; set; }

        [DataMember(Name = "vote_count")]
        public int VoteCount { get; set; }

        [DataMember(Name = "season_number")]
        public int SeasonNumber { get; set; }

        [DataMember(Name = "vote_average")]
        public double VoteAverage { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        public string HeName { get; set; }

        [DataMember(Name = "still_path")]
        public string StillPath { get; set; }

        [DataMember(Name = "overview")]
        public string Overview { get; set; }
        public string HeOverview { get; set; }

        [DataMember(Name = "poster_path")]
        public string PosterPath { get; set; }

        [DataMember(Name = "production_code")]
        public string ProductionCode { get; set; }
    }
}