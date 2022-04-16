using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Reko.Models.Dto
{
    public class CreditDto : BaseDto<int>
    {
        [DataMember(Name = "cast")]
        public IEnumerable<CastMemberDto> CastMembers { get; set; }

        [DataMember(Name = "crew")]
        public IEnumerable<CrewMemberDto> CrewMembers { get; set; }
    }
}