using System.Runtime.Serialization;
using Reko.Models.Enums;

namespace Reko.Models.Dto
{
    public class TVShowCreatorDto : BaseDto<int>
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "profile_path")]
        public string ProfilePath { get; set; }

        [DataMember(Name = "credit_id")]
        public string CreditId { get; set; }

        [DataMember(Name = "gender")]
        public Gender Gender { get; set; }
    }
}