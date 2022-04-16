using System.Runtime.Serialization;

namespace Reko.Models.Dto
{
    public class ParentCompanyDto : BaseDto<int>
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "logo_path")]
        public string LogoPath { get; set; }
    }
}