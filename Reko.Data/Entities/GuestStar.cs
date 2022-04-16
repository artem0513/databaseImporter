using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Reko.Data.ProfileData;
using Reko.Models.Dto;
using Reko.Models.Enums;

namespace Reko.Data.Entities
{
    public class GuestStar : IMappableEntity<GuestStar, GuestStarDto, int>
    {
        public int Id { get; set; }
        public int Order { get; set; }

        [MaxLength(700)]
        public string Character { get; set; }

        [MaxLength(800)]
        public string KnownForDepartment { get; set; }

        [MaxLength(1200)]
        public string Name { get; set; }

        [MaxLength(1200)]
        public string OriginalName { get; set; }

        [MaxLength(2048)]
        public string ProfilePath { get; set; }

        public bool Adult { get; set; }
        public Gender? Gender { get; set; }
        public double Popularity { get; set; }

        [MaxLength(500)]
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