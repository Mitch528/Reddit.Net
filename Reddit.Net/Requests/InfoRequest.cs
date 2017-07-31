using System;
using System.Collections.Generic;
using System.Text;
using RedditNet.Requests.Attributes;

namespace RedditNet.Requests
{
    public class InfoRequest : ListingRequest
    {
        [RequestProperty("id")]
        public string Ids { get; set; }

        [RequestProperty("url")]
        public string Url { get; set; }
    }
}
