using RedditNet.Requests.Attributes;

namespace RedditNet.Requests
{
    public class GetCommentRequest : GetCommentsRequest
    {
        public string LinkId { get; set; }

        [RequestProperty("comments")]
        public string CommentId { get; set; }
    }
}
