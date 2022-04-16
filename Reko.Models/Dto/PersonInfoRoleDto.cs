using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Reko.Models.Enums;
using Reko.Models.JsonConverters;

namespace Reko.Models.Dto
{
    public class PersonInfoRoleDto : BaseDto<int>
    {
        [DataMember(Name = "media_type")]
        public MediaType MediaType { get; set; }

        [DataMember(Name = "name")]
        public string TVShowName { get; set; }

        [DataMember(Name = "original_name")]
        public string TVShowOriginalName { get; set; }

        [DataMember(Name = "title")]
        public string MovieTitle { get; set; }

        [DataMember(Name = "original_title")]
        public string MovieOriginalTitle { set; get; }

        [DataMember(Name = "backdrop_path")]
        public string BackdropPath { get; set; }

        [DataMember(Name = "poster_path")]
        public string PosterPath { get; set; }

        [DataMember(Name = "release_date")]
        [JsonConverter(typeof(InvalidDateTimeFormatJsonConverter))]
        public DateTime MovieReleaseDate { get; set; }

        [DataMember(Name = "first_air_date")]
        [JsonConverter(typeof(InvalidDateTimeFormatJsonConverter))]
        public DateTime TVShowFirstAirDate { get; set; }

        [DataMember(Name = "overview")]
        public string Overview { get; set; }

        [DataMember(Name = "adult")]
        public bool IsAdultThemed { get; set; }

        [DataMember(Name = "video")]
        public bool IsVideo { get; set; }

        [DataMember(Name = "genre_ids")]
        public IReadOnlyList<int> GenreIds { get; set; }

        public IReadOnlyList<GenreDto> Genres { get; set; }

        [DataMember(Name = "original_language")]
        public string OriginalLanguage { get; set; }

        [DataMember(Name = "popularity")]
        public double Popularity { get; set; }

        [DataMember(Name = "vote_count")]
        public int VoteCount { get; set; }

        [DataMember(Name = "vote_average")]
        public double VoteAverage { get; set; }

        [DataMember(Name = "origin_country")]
        public IReadOnlyList<string> OriginCountry { get; set; }
    }
}