using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace RedditNet.Things
{
    [JsonObject]
    public class More : Thing, IEnumerable<string>
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("parent_id")]
        public string ParentId { get; set; }

        [JsonProperty("children")]
        public List<string> Children { get; set; } = new List<string>();

        public IEnumerator<string> GetEnumerator()
        {
            return Children.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
