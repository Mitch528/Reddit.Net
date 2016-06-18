using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RedditNet.Utils;

namespace RedditNet.Json
{
    public class EpochDateTimeConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(value);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            string timeStr = token.Value<string>();

            double time;
            if (double.TryParse(timeStr, out time))
                return DateUtils.FromUnixTime((long)time);

            return existingValue;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTime) || objectType == typeof(long);
        }

        public override bool CanRead => true;
    }
}
