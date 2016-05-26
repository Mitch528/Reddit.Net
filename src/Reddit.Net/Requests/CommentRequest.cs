using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Reddit.Net.Requests.Attributes;

namespace Reddit.Net.Requests
{
    public class CommentRequest : RedditRequestBase
    {
        [RequestProperty("text")]
        public string Text { get; set; }

        [RequestProperty("thing_id")]
        public string ThingId { get; set; }
    }
}
