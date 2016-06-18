using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using RedditNet.Things;

namespace RedditNet
{
    [JsonObject]
    public class Listing : IEnumerable<Thing>
    {
        [JsonIgnore]
        public RedditApi Api { get; set; }

        [JsonIgnore]
        internal string Url { get; set; }

        [JsonProperty("before")]
        public string Before { get; set; }

        [JsonProperty("after")]
        public string After { get; set; }

        [JsonProperty("children")]
        public List<Thing> Children { get; set; } = new List<Thing>();

        public int Count => Children.Count;

        public IEnumerator<Thing> GetEnumerator()
        {
            return Children.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
