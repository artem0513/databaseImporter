using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Reko.Models.Dto;

namespace Reko.Models.JsonConverters
{
    internal class KeywordConverter : JsonConverter
    {
        private readonly string _key;

        public KeywordConverter(string key)
        {
            _key = key;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var obj = JToken.Load(reader);

            var arr = (JArray) obj[_key];

            var keywords = arr.ToObject<IReadOnlyList<KeywordDto>>();

            return keywords;
        }

        public override bool CanConvert(Type objectType)
        {
            return false;
        }
    }
}