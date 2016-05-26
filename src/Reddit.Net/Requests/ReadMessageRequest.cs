using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Reddit.Net.Requests.Attributes;

namespace Reddit.Net.Requests
{
    public class ReadMessageRequest : RedditRequestBase
    {
        [RequestProperty("id")]
        public string Id { get; set; }
    }
}
