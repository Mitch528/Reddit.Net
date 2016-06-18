using Newtonsoft.Json;

namespace RedditNet.Things
{
    public interface IThing
    {
        [JsonIgnore]
        RedditApi Api { get; set; }

        [JsonProperty("id")]
        string Id { get; set; }

        [JsonProperty("name")]
        string FullName { get; set; }
    }
}
