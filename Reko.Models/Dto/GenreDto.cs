using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Reko.Models.Dto
{
    public class GenreDto : BaseDto<int>
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }
        public string HeName { get; set; }
    }
}