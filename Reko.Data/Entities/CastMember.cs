using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Reko.Data.ProfileData;
using Reko.Models.Dto;
using Reko.Models.Enums;

namespace Reko.Data.Entities
{
    public class CastMember : IMappableEntity<CastMember, CastMemberDto, int>
    {
        public int Id { get; set; }
        public bool Adult { get; set; }
        public Gender? Gender { get; set; }

        [MaxLength(1000)]
        public string KnownForDepartment { get; set; }

        [MaxLength(1400)]
        public string Name { get; set; }

        [MaxLength(1400)]
        public string OriginalName { get; set; }

        [MaxLength(800)]
        public string Character { get; set; }

        [MaxLength(200)]
        public string CreditId { get; set; }

        public double Popularity { get; set; }

        [MaxLength(2048)]
        public string ProfilePath { get; set; }

        public int? CastId { get; set; }
        public int Order { get; set; }

        public List<TvShow> TvShows { get; set; }
        public List<Movie> Movies { get; set; }


        public CastMember()
        {
            TvShows = new List<TvShow>();
            Movies = new List<Movie>();
        }

        public CastMemberDto ToDto()
        {
            return RekoMapperProfile.Mapper.Map<CastMemberDto>(this);
        }

        public CastMember FromDto(CastMemberDto dto)
        {
            RekoMapperProfile.Mapper.Map(dto, this);
            return this;
        }
    }
}