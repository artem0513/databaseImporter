using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Reko.Models.JsonConverters;

namespace Reko.Models.Dto
{
    public class TVShowDto : BaseDto<int>
    {
        [DataMember(Name = "backdrop_path")]
        public string BackdropPath { get; set; }

        [DataMember(Name = "created_by")]
        public IEnumerable<TVShowCreatorDto> CreatedBy { get; set; }

        [DataMember(Name = "episode_run_time")]
        public IEnumerable<int> EpisodeRunTime { get; set; }

        [DataMember(Name = "first_air_date")]
        public DateTime? FirstAirDate { get; set; }

        [DataMember(Name = "genres")]
        public IEnumerable<GenreDto> Genres { get; set; }

        [DataMember(Name = "homepage")]
        public string Homepage { get; set; }

        [DataMember(Name = "in_production")]
        public bool InProduction { get; set; }

        [DataMember(Name = "languages")]
        public IEnumerable<string> Languages { get; set; }

        [DataMember(Name = "last_air_date")]
        public DateTime LastAirDate { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "he_name")]
        public string HeName { get; set; }

        [DataMember(Name = "networks")]
        public IEnumerable<NetworkDto> Networks { get; set; }

        [DataMember(Name = "number_of_episodes")]
        public int? NumberOfEpisodes { get; set; }

        [DataMember(Name = "number_of_seasons")]
        public int? NumberOfSeasons { get; set; }

        [DataMember(Name = "origin_country")]
        public IEnumerable<string> OriginCountry { get; set; }

        [DataMember(Name = "original_language")]
        public string OriginalLanguage { get; set; }

        [DataMember(Name = "original_name")]
        public string OriginalName { get; set; }

        [DataMember(Name = "overview")]
        public string Overview { get; set; }

        [DataMember(Name = "he_overview")]
        public string HeOverview { get; set; }

        [DataMember(Name = "popularity")]
        public double? Popularity { get; set; }

        [DataMember(Name = "poster_path")]
        public string PosterPath { get; set; }

        [DataMember(Name = "production_companies")]
        public IEnumerable<ProductionCompanyDto> ProductionCompanies { get; set; }

        [DataMember(Name = "seasons")]
        public IEnumerable<SeasonDto> Seasons { get; set; }

        [DataMember(Name = "keywords")]
        [JsonConverter(typeof(KeywordConverter), "results")]
        public IEnumerable<KeywordDto> Keywords { get; set; }

        [DataMember(Name = "credits")]
        public CreditDto Credit { get; set; }

        [DataMember(Name = "videos")]
        public VideosDto Videos { get; set; }
    }
}