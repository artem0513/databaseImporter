using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Reko.Data.ProfileData;
using Reko.Models.Dto;
using Reko.Models.Enums;

namespace Reko.Data.Entities
{
    public sealed class TvShowCreator : IMappableEntity<TvShowCreator, TVShowCreatorDto, int>
    {
        public int Id { get; set; }

        [MaxLength(800)]
        public string Name { get; set; }

        [MaxLength(2048)]
        public string ProfilePath { get; set; }

        [MaxLength(700)]
        public string CreditId { get; set; }

        public Gender Gender { get; set; }
        public List<TvShow> TvShows { get; set; }

        public TvShowCreator()
        {
            TvShows = new List<TvShow>();
        }

        public TVShowCreatorDto ToDto()
        {
            return RekoMapperProfile.Mapper.Map<TVShowCreatorDto>(this);
        }

        public TvShowCreator FromDto(TVShowCreatorDto dto)
        {
            RekoMapperProfile.Mapper.Map(dto, this);
            return this;
        }
    }
}