using RedditNet.Requests.Attributes;

namespace RedditNet.Requests
{
    public class MessageRequest : ListingRequest
    {
        [RequestProperty("mark")]
        public bool Mark { get; set; }

        [RequestProperty("mid")]
        public string Mid { get; set; }

        [RequestProperty("show")]
        public string Show { get; set; }

        [RequestProperty("sr_detail")]
        public bool SrDetail { get; set; }

        public MessageType Type { get; set; }
    }
}
