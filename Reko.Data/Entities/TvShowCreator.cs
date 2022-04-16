using System.Collections.Generic;
using Reko.Data.ProfileData;
using Reko.Models.Dto;
using Reko.Models.Enums;

namespace Reko.Data.Entities
{
    public sealed class TvShowCreator : IMappableEntity<TvShowCreator, TVShowCreatorDto, int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProfilePath { get; set; }
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