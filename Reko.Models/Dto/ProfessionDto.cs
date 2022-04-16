using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Reko.Models.Dto
{
    public class ProfessionDto : BaseDto<int>
    {
        [DataMember(Name = "department")]
        public string Department { get; set; }

        [DataMember(Name = "jobs")]
        public IReadOnlyList<string> Jobs { get; set; }
    }
}