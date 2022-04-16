using System.Runtime.Serialization;
using Reko.Models.Enums;

namespace Reko.Models.Dto
{
    public class CastMemberDto : BaseDto<int>
    {
        [DataMember(Name = "adult")]
        public bool Adult { get; set; }

        [DataMember(Name = "gender")]
        public Gender? Gender { get; set; }

        [DataMember(Name = "known_for_department")]
        public string KnownForDepartment { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "original_name")]
        public string OriginalName { get; set; }

        [DataMember(Name = "character")]
        public string Character { get; set; }

        [DataMember(Name = "credit_id")]
        public string CreditId { get; set; }

        [DataMember(Name = "popularity")]
        public double Popularity { get; set; }

        [DataMember(Name = "profile_path")]
        public string ProfilePath { get; set; }

        [DataMember(Name = "cast_id")]
        public int? CastId { get; set; }

        [DataMember(Name = "order")]
        public int Order { get; set; }

        public override string ToString()
        {
            return $"{Character}: {Name}";
        }
    }
}