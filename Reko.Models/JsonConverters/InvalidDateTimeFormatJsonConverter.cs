using System;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Reko.Models.JsonConverters
{
    public class InvalidDateTimeFormatJsonConverter : DateTimeConverterBase
    {
        private const string Format = "yyyy-MM-dd";

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(((DateTime) value).ToString(Format));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value == null)
            {
                return null;
            }

            var val = reader.Value.ToString();

            if (val?.Length == 4 && int.TryParse(val, out var year))
            {
                return new DateTime(year, 1, 1);
            }

            if (DateTime.TryParseExact(val, Format, CultureInfo.InvariantCulture, DateTimeStyles.None, out var result))
            {
                return result;
            }

            return null;
        }

        public override bool CanConvert(Type objectType)
        {
            return true;
        }
    }
}