using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reddit.Net.Requests.Attributes;

namespace Reddit.Net.Requests
{
    public class GetCommentsRequest : ListingRequest
    {
        [RequestProperty("context")]
        public int? Context { get; set; }

        [RequestProperty("depth")]
        public int? Depth { get; set; }

        [RequestProperty("showedits")]
        public bool ShowEdits { get; set; } = true;

        [RequestProperty("showmore")]
        public bool ShowMore { get; set; } = true;

        [RequestProperty("sort")]
        public CommentSort Sort { get; set; } = CommentSort.Top;

        [RequestProperty("sr_detail")]
        public bool? SrDetail { get; set; }
    }
}
