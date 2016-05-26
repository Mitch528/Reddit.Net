using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Reddit.Net.Things;

namespace Reddit.Net.Responses
{
    public class LinkSubmittedResponse : Thing
    {
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
