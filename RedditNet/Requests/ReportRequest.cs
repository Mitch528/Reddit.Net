using RedditNet.Requests.Attributes;

namespace RedditNet.Requests
{
    public class ReportRequest : RedditRequestBase
    {
        [RequestProperty("other_reason")]
        public string OtherReason { get; set; }

        [RequestProperty("reason")]
        public string Reason { get; set; }

        [RequestProperty("site_reason")]
        public string SiteReason { get; set; }

        [RequestProperty("thing_id")]
        public string ThingId { get; set; }
    }
}
