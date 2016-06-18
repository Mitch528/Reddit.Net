using RedditNet.Requests.Attributes;

namespace RedditNet.Requests
{
    public class ReadMessageRequest : RedditRequestBase
    {
        [RequestProperty("id")]
        public string Id { get; set; }
    }
}
