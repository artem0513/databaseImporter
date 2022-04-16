using System.Collections.Generic;
using Reko.Data.ProfileData;
using Reko.Models.Dto;

namespace Reko.Data.Entities
{
    public class KeyWord : IMappableEntity<KeyWord, KeywordDto, int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Movie> Movies { get; set; }
        public List<TvShow> TvShows { get; set; }

        public KeyWord()
        {
            Movies = new List<Movie>();
            TvShows = new List<TvShow>();
        }

        public KeywordDto ToDto()
        {
            return RekoMapperProfile.Mapper.Map<KeywordDto>(this);
        }

        public KeyWord FromDto(KeywordDto dto)
        {
            RekoMapperProfile.Mapper.Map(dto, this);
            return this;
        }
    }
}