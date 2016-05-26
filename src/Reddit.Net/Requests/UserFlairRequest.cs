using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reddit.Net.Requests.Attributes;

namespace Reddit.Net.Requests
{
    public class UserFlairRequest : RedditRequestBase
    {
        [RequestProperty("css_class")]
        public string CssClass { get; set; }

        [RequestProperty("name")]
        public string Username { get; set; }

        [RequestProperty("link")]
        public string Link { get; set;}

        [RequestProperty("text")]
        public string Text { get; set; }
        
        [RequestProperty("r")]
        public string Subreddit { get; set; }
    }
}
