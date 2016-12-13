using System;
using Newtonsoft.Json;
using RedditNet.Json;

namespace RedditNet.Things
{
    public interface ICreated
    {
        [JsonProperty("created")]
        [JsonConverter(typeof(EpochDateTimeConverter))]
        DateTime CreatedLocal { get; set; }

        [JsonProperty("created_utc")]
        [JsonConverter(typeof(EpochDateTimeConverter))]
        DateTime CreatedUtc { get; set; }
    }
}
