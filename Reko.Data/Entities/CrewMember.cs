using System.Collections.Generic;
using Reko.Data.ProfileData;
using Reko.Models.Dto;
using Reko.Models.Enums;

namespace Reko.Data.Entities
{
    public class CrewMember : IMappableEntity<CrewMember, CrewMemberDto, int>
    {
        public int Id { get; set; }
        public bool Adult { get; set; }
        public Gender? Gender { get; set; }
        public string KnownForDepartment { get; set; }
        public string Name { get; set; }
        public string OriginalName { get; set; }
        public string Character { get; set; }
        public string CreditId { get; set; }
        public double Popularity { get; set; }
        public string ProfilePath { get; set; }
        public int CastId { get; set; }
        public int Order { get; set; }
        public List<Movie> Movies { get; set; }
        public List<Episode> Episodes { get; set; }
        public List<TvShow> TvShows { get; set; }

        public CrewMember()
        {
            Movies = new List<Movie>();
            Episodes = new List<Episode>();
            TvShows = new List<TvShow>();
        }

        public CrewMemberDto ToDto()
        {
            return RekoMapperProfile.Mapper.Map<CrewMemberDto>(this);
        }

        public CrewMember FromDto(CrewMemberDto dto)
        {
            RekoMapperProfile.Mapper.Map(dto, this);
            return this;
        }
    }
}