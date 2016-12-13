using RedditNet.Requests.Attributes;

namespace RedditNet.Requests
{
    public class EditUserTextRequest : RedditRequestBase
    {
        [RequestProperty("text")]
        public string Text { get; set; }

        [RequestProperty("thing_id")]
        public string ThingId { get; set; }
    }
}
