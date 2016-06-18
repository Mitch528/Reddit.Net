using RedditNet.Requests.Attributes;

namespace RedditNet.Requests
{
    public class ContestModeRequest : RedditRequestBase
    {
        [RequestProperty("id")]
        public string Id { get; set; }

        [RequestProperty("state")]
        public bool State { get; set; }
    }
}
