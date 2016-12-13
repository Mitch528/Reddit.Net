using RedditNet.Requests.Attributes;

namespace RedditNet.Requests
{
    public class UnreadMessageRequest : RedditRequestBase
    {
        [RequestProperty("id")]
        public string Id { get; set; }
    }
}
