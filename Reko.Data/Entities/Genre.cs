using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Reko.Data.ProfileData;
using Reko.Models.Dto;

namespace Reko.Data.Entities
{
    public sealed class Genre : IMappableEntity<Genre, GenreDto, int>
    {
        public int Id { get; set; }

        [MaxLength(200)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string HeName { get; set; }

        public ICollection<Movie> Movies { get; set; }
        public ICollection<TvShow> TvShows { get; set; }

        public Genre()
        {
            Movies = new List<Movie>();
            TvShows = new List<TvShow>();
        }

        public GenreDto ToDto()
        {
            return RekoMapperProfile.Mapper.Map<GenreDto>(this);
        }

        public Genre FromDto(GenreDto dto)
        {
            RekoMapperProfile.Mapper.Map(dto, this);
            return this;
        }
    }
}