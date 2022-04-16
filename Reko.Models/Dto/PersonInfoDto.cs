using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Reko.Models.Dto
{
    public class PersonInfoDto : BaseDto<int>
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "adult")]
        public bool IsAdultFilmStar { get; set; }

        [DataMember(Name = "known_for")]
        public IReadOnlyList<PersonInfoRoleDto> KnownFor { get; set; }

        [DataMember(Name = "profile_path")]
        public string ProfilePath { get; set; }

        [DataMember(Name = "popularity")]
        public double Popularity { get; set; }
    }
}