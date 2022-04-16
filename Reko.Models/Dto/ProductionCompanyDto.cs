using System.Runtime.Serialization;

namespace Reko.Models.Dto
{
    public class ProductionCompanyDto : BaseDto<int>
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "headquarters")]
        public string Headquarters { get; set; }

        [DataMember(Name = "homepage")]
        public string Homepage { get; set; }

        [DataMember(Name = "logo_path")]
        public string LogoPath { get; set; }

        [DataMember(Name = "parent_company")]
        public ParentCompanyDto ParentCompany { get; set; }
    }
}