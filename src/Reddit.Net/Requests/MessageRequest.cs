using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reddit.Net.Requests.Attributes;

namespace Reddit.Net.Requests
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
