using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Reko.Data.ProfileData;
using Reko.Models.Dto;

namespace Reko.Data.Entities
{
    public sealed class Movie : IMappableEntity<Movie, MovieDto, int>
    {
        public int Id { get; set; }

        [MaxLength(1200)]
        public string Title { get; set; }

        [MaxLength(1200)]
        public string HeTitle { get; set; }

        public bool IsAdultThemed { get; set; }

        [MaxLength(2048)]
        public string BackdropPath { get; set; }

        public int? Budget { get; set; }

        [MaxLength(2048)]
        public string Homepage { get; set; }

        [MaxLength(200)]
        public string ImdbId { get; set; }

        [MaxLength(200)]
        public string OriginalLanguage { get; set; }

        [MaxLength(1200)]
        public string OriginalTitle { get; set; }

        [MaxLength(7000)]
        public string Overview { get; set; }

        [MaxLength(7000)]
        public string HeOverview { get; set; }

        public double? Popularity { get; set; }

        [MaxLength(2048)]
        public string PosterPath { get; set; }

        public DateTime? ReleaseDate { get; set; }
        public decimal? Revenue { get; set; }
        public int? Runtime { get; set; }

        [MaxLength(500)]
        public string Status { get; set; }

        [MaxLength(2048)]
        public string Tagline { get; set; }

        public bool IsVideo { get; set; }
        public double? VoteAverage { get; set; }
        public int? VoteCount { get; set; }
        public int? CollectionInfoId { get; set; }
        public CollectionInfo CollectionInfo { get; set; }
        public List<Genre> Genres { get; set; }
        public List<ProductionCompany> ProductionCompanies { get; set; }
        public List<Country> Countries { get; set; }
        public List<Language> Languages { get; set; }
        public List<KeyWord> KeyWords { get; set; }
        public List<Video> Videos { get; set; }
        public List<CastMember> CastMembers { get; set; }
        public List<CrewMember> CrewMembers { get; set; }

        public Movie()
        {
            Genres = new List<Genre>();
            ProductionCompanies = new List<ProductionCompany>();
            Countries = new List<Country>();
            Languages = new List<Language>();
            KeyWords = new List<KeyWord>();
            Videos = new List<Video>();
            CastMembers = new List<CastMember>();
            CrewMembers = new List<CrewMember>();
        }

        public MovieDto ToDto()
        {
            return RekoMapperProfile.Mapper.Map<MovieDto>(this);
        }

        public Movie FromDto(MovieDto dto)
        {
            RekoMapperProfile.Mapper.Map(dto, this);
            return this;
        }
    }
}