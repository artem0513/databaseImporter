using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Reko.Models.JsonConverters;

namespace Reko.Models.Dto
{
    public class SeasonDto : BaseDto<int>
    {
        [DataMember(Name = "air_date")]
        [JsonConverter(typeof(InvalidDateTimeFormatJsonConverter))]
        public DateTime? AirDate { get; set; }

        [DataMember(Name = "poster_path")]
        public string PosterPath { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        public string HeName { get; set; }

        [DataMember(Name = "overview")]
        public string Overview { get; set; }

        public string HeOverview { get; set; }

        [DataMember(Name = "season_number")]
        public int SeasonNumber { get; set; }

        [DataMember(Name = "episodes")]
        public IEnumerable<EpisodeDto> Episodes { get; set; }
    }
}