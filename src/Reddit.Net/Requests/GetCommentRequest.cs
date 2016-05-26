using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reddit.Net.Requests.Attributes;

namespace Reddit.Net.Requests
{
    public class GetCommentRequest : GetCommentsRequest
    {
        public string LinkId { get; set; }

        [RequestProperty("comments")]
        public string CommentId { get; set; }
    }
}
