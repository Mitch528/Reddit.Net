using System.Runtime.Serialization;
using RedditNet.Requests.Attributes;

namespace RedditNet.Requests
{
    public class LinkSubmitRequest : RedditRequestBase
    {
        [RequestProperty("captcha")]
        public string Captcha { get; set; }

        [RequestProperty("extension")]
        public string Extension { get; set; }

        [RequestProperty("iden")]
        public string Iden { get; set; }
        
        [RequestProperty("kind")]
        public LinkKind Kind { get; set; }

        [RequestProperty("resubmit")]
        public bool Resubmit { get; set; }

        [RequestProperty("sendreplies")]
        public bool SendReplies { get; set; }

        [RequestProperty("sr")]
        public string Subreddit { get; set; }

        [RequestProperty("text")]
        public string Text { get; set; }

        [RequestProperty("title")]
        public string Title { get; set; }

        [RequestProperty("url")]
        public string Url { get; set; }
    }

    public enum LinkKind
    {
        [EnumMember(Value = "link")]
        Link,
        [EnumMember(Value = "self")]
        Self
    }
}
