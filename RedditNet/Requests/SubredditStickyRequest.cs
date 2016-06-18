using RedditNet.Requests.Attributes;

namespace RedditNet.Requests
{
    public class SubredditStickyRequest : RedditRequestBase
    {
        [RequestProperty("id")]
        public string Id { get; set; }

        [RequestProperty("num")]
        public int? Num { get; set; }

        [RequestProperty("state")]
        public bool State { get; set; }
    }
}
