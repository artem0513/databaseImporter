using System.Runtime.Serialization;
using Reko.Models.Enums;

namespace Reko.Models.Dto
{
    public class CrewMemberDto : BaseDto<int>
    {
        [DataMember(Name = "credit_id")]
        public string CreditId { get; set; }

        [DataMember(Name = "adult")]
        public bool Adult { get; set; }

        [DataMember(Name = "department")]
        public string Department { get; set; }

        [DataMember(Name = "known_for_department")]
        public string KnownForDepartment { get; set; }

        [DataMember(Name = "gender")]
        public Gender? Gender { get; set; }

        [DataMember(Name = "job")]
        public string Job { get; set; }

        [DataMember(Name = "popularity")]
        public double Popularity { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "original_name")]
        public string OriginalName { get; set; }

        [DataMember(Name = "profile_path")]
        public string ProfilePath { get; set; }
    }
}