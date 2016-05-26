using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Reddit.Net.Json;

namespace Reddit.Net.Things
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
