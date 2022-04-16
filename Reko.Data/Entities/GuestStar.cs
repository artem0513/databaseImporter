using System.Collections.Generic;
using Reko.Data.ProfileData;
using Reko.Models.Dto;
using Reko.Models.Enums;

namespace Reko.Data.Entities
{
    public class GuestStar : IMappableEntity<GuestStar, GuestStarDto, int>
    {
        public int Id { get; set; }
        public int Order { get; set; }
        public string Character { get; set; }
        public string KnownForDepartment { get; set; }
        public string Name { get; set; }
        public string OriginalName { get; set; }
        public string ProfilePath { get; set; }
        public bool Adult { get; set; }
        public Gender? Gender { get; set; }
        public double Popularity { get; set; }
        public string CreditId { get; set; }
        public List<Episode> Episodes { get; set; }

        public GuestStar()
        {
            Episodes = new List<Episode>();
        }

        public GuestStarDto ToDto()
        {
            return RekoMapperProfile.Mapper.Map<GuestStarDto>(this);
        }

        public GuestStar FromDto(GuestStarDto dto)
        {
            RekoMapperProfile.Mapper.Map(dto, this);
            return this;
        }
    }
}