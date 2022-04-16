using System;
using System.Runtime.Serialization;

namespace Reko.Models.Dto
{
    public class VideoDto : BaseDto<string>
    {
        [DataMember(Name = "iso_639_1")]
        public string Iso6391 { get; set; }

        [DataMember(Name = "iso_3166_1")]
        public string Iso31661 { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "key")]
        public string Key { get; set; }

        [DataMember(Name = "site")]
        public string Site { get; set; }

        [DataMember(Name = "size")]
        public int? Size { get; set; }

        [DataMember(Name = "type")]
        public string Type { get; set; }

        [DataMember(Name = "official")]
        public bool IsOfficial { get; set; }

        [DataMember(Name = "published_at")]
        public DateTime? PublishedAt { get; set; }
    }
}