using Newtonsoft.Json;

namespace RedditNet.Things
{
    public interface IVotable
    {
        [JsonProperty("ups")]
        int Ups { get; set; }

        [JsonProperty("downs")]
        int Downs { get; set; }

        [JsonProperty("likes")]
        bool? Likes { get; set; }
    }
}
