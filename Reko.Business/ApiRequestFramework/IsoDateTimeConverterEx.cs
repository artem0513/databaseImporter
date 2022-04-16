using System;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Reko.Business.ApiRequestFramework
{
    public class IsoDateTimeConverterEx : IsoDateTimeConverter
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            ConditionalTraceReaderValue(reader);

            try
            {
                return base.ReadJson(reader, objectType, existingValue, serializer);
            }
            catch (Exception ex) when (ex is FormatException
                                       || ex is JsonSerializationException jse
                                       && jse.Message.Contains("System.DateTime"))
            {
                var val = reader.Value?.ToString();

                if (val?.Length == 4 && int.TryParse(val, out var year))
                {
                    return new DateTime(year, 1, 1);
                }

                return default(DateTime);
            }
        }

        [Conditional("DEBUG")]
        private static void ConditionalTraceReaderValue(JsonReader reader)
        {
            var val = reader.Value?.ToString();
            if (string.IsNullOrWhiteSpace(val))
            {
                val = "<empty>";
            }

            Debug.WriteLine($"IsoDateTimeConverterEx.JsonReader.Value: {val}");
        }
    }
}