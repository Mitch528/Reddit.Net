using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reddit.Net.Requests.Attributes;

namespace Reddit.Net.Requests
{
    public class UserRequest : ListingRequest
    {
        [RequestProperty("show")]
        public string Show { get; set; }

        [RequestProperty("sort")]
        public UserSort Sort { get; set; }

        [RequestProperty("t")]
        public TimeSort TimeSort { get; set; }

        [RequestProperty("username")]
        public string Username { get; set; }

        [RequestProperty("sr_detail")]
        public bool SrDetail { get; set; }

        public UserRequestType Type { get; set; }
    }

    public enum UserRequestType
    {
        Overview,
        Submitted,
        Comments,
        Upvoted,
        Downvoted,
        Hidden,
        Saved,
        Gilded
    }
}
