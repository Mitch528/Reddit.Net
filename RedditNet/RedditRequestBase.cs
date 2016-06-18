using RedditNet.Requests.Attributes;

namespace RedditNet
{
    public abstract class RedditRequestBase
    {
        [RequestProperty("api_type")]
        public string ApiType { get; } = "json";
    }
}
