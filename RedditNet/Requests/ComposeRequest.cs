using RedditNet.Requests.Attributes;

namespace RedditNet.Requests
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
