using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Reddit.Net.Requests.Attributes;

namespace Reddit.Net.Requests
{
    public class ComposeRequest : RedditRequestBase
    {
        [RequestProperty("captcha")]
        public string Captcha { get; set; }

        [RequestProperty("from_sr")]
        public string FromSr { get; set; }

        [RequestProperty("iden")]
        public string Iden { get; set; }

        [RequestProperty("subject")]
        public string Subject { get; set; }

        [RequestProperty("text")]
        public string Text { get; set; }

        [RequestProperty("to")]
        public string To { get; set; }
    }
}
