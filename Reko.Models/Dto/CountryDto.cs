using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Reko.Models.Dto
{
    public class CountryDto : BaseDto<string>
    {
        [DataMember(Name = "iso_3166_1")]
        public override string Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}