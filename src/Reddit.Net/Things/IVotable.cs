using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Reddit.Net.Things
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
