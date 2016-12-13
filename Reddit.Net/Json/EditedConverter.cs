using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RedditNet.Things;
using RedditNet.Utils;

namespace RedditNet.Json
{
    public class EditedConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            string special = token.Value<string>();

            Edited edit = new Edited { IsEdited = special == "true" };

            if (!edit.IsEdited)
            {
                double timeEdited;
                if (double.TryParse(special, out timeEdited))
                {
                    edit.IsEdited = true;
                    edit.TimeEdited = DateUtils.FromUnixTime((long)timeEdited);
                }
            }

            return edit;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Edited);
        }

        public override bool CanRead => true;
    }
}
