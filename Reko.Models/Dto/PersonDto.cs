using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Reko.Models.Enums;
using Reko.Models.JsonConverters;

namespace Reko.Models.Dto
{
    public class PersonDto : BaseDto<int>
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "also_known_as")]
        public IReadOnlyList<string> AlsoKnownAs { get; set; }

        [DataMember(Name = "adult")]
        public bool IsAdultFilmStar { get; set; }

        [DataMember(Name = "biography")]
        public string Biography { get; set; }

        [DataMember(Name = "birthday")]
        [JsonConverter(typeof(InvalidDateTimeFormatJsonConverter))]
        public DateTime Birthday { get; set; }

        [DataMember(Name = "deathday")]
        [JsonConverter(typeof(InvalidDateTimeFormatJsonConverter))]
        public DateTime Deathday { get; set; }

        [DataMember(Name = "gender")]
        public Gender Gender { get; set; }

        [DataMember(Name = "homepage")]
        public string Homepage { get; set; }

        [DataMember(Name = "imdb_id")]
        public string ImdbId { get; set; }

        [DataMember(Name = "place_of_birth")]
        public string PlaceOfBirth { get; set; }

        [DataMember(Name = "popularity")]
        public double Popularity { get; set; }

        [DataMember(Name = "profile_path")]
        public string ProfilePath { get; set; }

        public override string ToString() => Name;
    }
}