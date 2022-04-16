using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Reko.Data.ProfileData;
using Reko.Models.Dto;

namespace Reko.Data.Entities
{
    public sealed class TvShow : IMappableEntity<TvShow, TVShowDto, int>
    {
        public int Id { get; set; }

        [MaxLength(2048)]
        public string BackdropPath { get; set; }

        [MaxLength(500)]
        public string EpisodeRunTime { get; set; }

        public DateTime? FirstAirDate { get; set; }

        [MaxLength(2048)]
        public string Homepage { get; set; }

        public bool InProduction { get; set; }

        [MaxLength(500)]
        public string Languages { get; set; }

        public DateTime? LastAirDate { get; set; }

        [MaxLength(1000)]
        public string Name { get; set; }

        [MaxLength(1000)]
        public string HeName { get; set; }

        public int? NumberOfEpisodes { get; set; }
        public int? NumberOfSeasons { get; set; }

        [MaxLength(200)]
        public string OriginCountry { get; set; }

        [MaxLength(50)]
        public string OriginalLanguage { get; set; }

        [MaxLength(1000)]
        public string OriginalName { get; set; }

        [MaxLength(7000)]
        public string Overview { get; set; }

        [MaxLength(7000)]
        public string HeOverview { get; set; }

        public double? Popularity { get; set; }

        [MaxLength(2048)]
        public string PosterPath { get; set; }

        public List<TvShowCreator> TvShowCreators { get; set; }
        public List<Genre> Genres { get; set; }
        public List<Network> Networks { get; set; }
        public List<ProductionCompany> ProductionCompanies { get; set; }
        public List<Season> Seasons { get; set; }
        public List<KeyWord> KeyWords { get; set; }
        public List<Video> Videos { get; set; }
        public List<CrewMember> CrewMembers { get; set; }
        public List<CastMember> CastMembers { get; set; }

        public TvShow()
        {
            TvShowCreators = new List<TvShowCreator>();
            Genres = new List<Genre>();
            Networks = new List<Network>();
            ProductionCompanies = new List<ProductionCompany>();
            Seasons = new List<Season>();
            KeyWords = new List<KeyWord>();
            Videos = new List<Video>();
            CrewMembers = new List<CrewMember>();
            CastMembers = new List<CastMember>();
        }

        public TVShowDto ToDto()
        {
            return RekoMapperProfile.Mapper.Map<TVShowDto>(this);
        }

        public TvShow FromDto(TVShowDto dto)
        {
            RekoMapperProfile.Mapper.Map(dto, this);
            return this;
        }
    }
}