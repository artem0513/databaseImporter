using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Reko.Models.JsonConverters;

namespace Reko.Models.Dto
{
    public class MovieDto : BaseDto<int>
    {
        [DataMember(Name = "title")]
        public string Title { get; set; }

        public string HeTitle { get; set; }

        [DataMember(Name = "adult")]
        public bool IsAdultThemed { get; set; }

        [DataMember(Name = "backdrop_path")]
        public string BackdropPath { get; set; }

        [DataMember(Name = "belongs_to_collection")]
        public CollectionInfoDto MovieCollectionInfo { get; set; }

        [DataMember(Name = "budget")]
        public int Budget { get; set; }

        [DataMember(Name = "genres")]
        public IEnumerable<GenreDto> Genres { get; set; }

        [DataMember(Name = "homepage")]
        public string Homepage { get; set; }

        [DataMember(Name = "imdb_id")]
        public string ImdbId { get; set; }

        [DataMember(Name = "original_language")]
        public string OriginalLanguage { get; set; }

        [DataMember(Name = "original_title")]
        public string OriginalTitle { get; set; }

        [DataMember(Name = "overview")]
        public string Overview { get; set; }

        public string HeOverview { get; set; }

        [DataMember(Name = "popularity")]
        public double Popularity { get; set; }

        [DataMember(Name = "poster_path")]
        public string PosterPath { get; set; }

        [DataMember(Name = "production_companies")]
        public IEnumerable<ProductionCompanyDto> ProductionCompanies { get; set; }

        [DataMember(Name = "production_countries")]
        public IEnumerable<CountryDto> ProductionCountries { get; set; }

        [DataMember(Name = "release_date")]
        [JsonConverter(typeof(InvalidDateTimeFormatJsonConverter))]
        public DateTime ReleaseDate { get; set; }

        [DataMember(Name = "revenue")]
        public decimal Revenue { get; set; }

        [DataMember(Name = "runtime")]
        public int Runtime { get; set; }

        [DataMember(Name = "spoken_languages")]
        public IEnumerable<LanguageDto> SpokenLanguages { get; set; }

        [DataMember(Name = "status")]
        public string Status { get; set; }

        [DataMember(Name = "tagline")]
        public string Tagline { get; set; }

        [DataMember(Name = "video")]
        public bool IsVideo { get; set; }

        [DataMember(Name = "vote_average")]
        public double VoteAverage { get; set; }

        [DataMember(Name = "vote_count")]
        public int VoteCount { get; set; }

        [DataMember(Name = "keywords")]
        [JsonConverter(typeof(KeywordConverter), "keywords")]
        public IEnumerable<KeywordDto> Keywords { get; set; }

        [DataMember(Name = "credits")]
        public CreditDto Credit { get; set; }

        [DataMember(Name = "videos")]
        public VideosDto Videos { get; set; }
    }
}