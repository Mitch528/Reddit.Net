using System;
using System.Collections.Generic;
using System.Text;

namespace RedditNet.Requests
{
    public class GetCommentRepliesRequest : ListingRequest
    {
        public string LinkId { get; set; }

        public string CommentId { get; set; }
    }
}
