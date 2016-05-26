using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Reddit.Net.Things
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
