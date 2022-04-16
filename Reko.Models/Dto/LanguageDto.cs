using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Reko.Models.Dto
{
    public class LanguageDto : BaseDto<string>
    {
        [DataMember(Name = "iso_639_1")]
        public override string Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}