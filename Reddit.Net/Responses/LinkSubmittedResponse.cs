using Newtonsoft.Json;
using RedditNet.Things;

namespace RedditNet.Responses
{
    public class LinkSubmittedResponse : Thing
    {
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
