using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Reko.Models.Dto
{
    public class KeywordDto : BaseDto<int>
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}