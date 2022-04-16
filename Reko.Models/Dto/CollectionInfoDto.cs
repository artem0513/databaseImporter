using System.Runtime.Serialization;

namespace Reko.Models.Dto
{
    public class CollectionInfoDto : BaseDto<int>
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "he_name")]
        public string HeName { get; set; }

        [DataMember(Name = "poster_path")]
        public string PosterPath { get; set; }

        [DataMember(Name = "backdrop_path")]
        public string BackdropPath { get; set; }

        public override string ToString()
        {
            return string.IsNullOrWhiteSpace(Name) ? "n/a" : $"{Name} ({Id})";
        }
    }
}