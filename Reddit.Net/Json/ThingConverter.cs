using System;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RedditNet.Things;

namespace RedditNet.Json
{
    public class ThingConverter : JsonConverter
    {
        private readonly RedditApi _api;

        public ThingConverter()
        {
        }

        public ThingConverter(RedditApi api)
        {
            _api = api;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            JToken obj = JToken.FromObject(value);
            obj.WriteTo(writer);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken obj = JToken.Load(reader);
            if (!obj.HasValues)
                return Activator.CreateInstance(objectType);

            if (obj["json"] != null)
                obj = obj["json"];

            if (obj["errors"] != null && obj["errors"].HasValues)
                throw new RedditApiException(obj["errors"].ToString());

            JToken data = obj["data"];

            string kind = obj["kind"]?.Value<string>().ToLower();
            if (kind == "listing")
            {
                Listing listing = new Listing { Api = _api };
                serializer.Populate(data.CreateReader(), listing);

                return listing;
            }

            Thing retVal;
            switch (kind)
            {
                case "t1":
                    retVal = new Comment();
                    break;
                case "t2":
                    retVal = new Account();
                    break;
                case "t3":
                    retVal = new Link();
                    break;
                case "t4":
                    retVal = new Message();
                    break;
                case "t5":
                    retVal = new Subreddit();
                    break;
                case "more":
                    retVal = new More();
                    break;
                default:
                    retVal = (Thing)Activator.CreateInstance(objectType);
                    break;
            }

            serializer.Populate(data.CreateReader(), retVal);

            retVal.Api = _api;

            return retVal;
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(IThing).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo()) ||
                typeof(Listing).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo());
        }

        public override bool CanRead => true;
    }
}
