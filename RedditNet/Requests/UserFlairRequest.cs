using RedditNet.Requests.Attributes;

namespace RedditNet.Requests
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
