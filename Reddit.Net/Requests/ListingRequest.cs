﻿using RedditNet.Requests.Attributes;

namespace RedditNet.Requests
{
    public class ListingRequest
    {
        public static readonly ListingRequest Default = new ListingRequest();

        [RequestProperty("before")]
        public string Before { get; set; }

        [RequestProperty("after")]
        public string After { get; set; }

        [RequestProperty("limit")]
        public int Limit { get; set; } = 25;
    }
}
