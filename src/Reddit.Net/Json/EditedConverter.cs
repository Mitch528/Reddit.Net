using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Reddit.Net.Things;
using Reddit.Net.Utils;

namespace Reddit.Net.Json
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
