using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reddit.Net.Requests.Attributes;

namespace Reddit.Net
{
    public abstract class RedditRequestBase
    {
        [RequestProperty("api_type")]
        public string ApiType { get; } = "json";
    }
}
