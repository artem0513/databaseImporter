using System;
using System.Diagnostics;
using System.Globalization;
using Microsoft.Data.SqlClient.Server;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Reko.Business.ApiRequestFramework
{
    public class IsoDateTimeConverterEx : IsoDateTimeConverter
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
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
            catch (Exception)
            {
                return default(DateTime);
            }
        }
    }
}