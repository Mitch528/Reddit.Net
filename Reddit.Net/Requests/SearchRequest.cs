using RedditNet.Requests.Attributes;

namespace RedditNet.Requests
{
    public class SearchRequest : ListingRequest
    {
        [RequestProperty("count")]
        public int? Count { get; set; }

        [RequestProperty("include_facets")]
        public bool IncludeFacets { get; set; }

        [RequestProperty("q")]
        public string Query { get; set; }

        [RequestProperty("restrict_sr")]
        public bool RestrictSr { get; set; }

        [RequestProperty("show")]
        public string Show { get; set; }

        [RequestProperty("sort")]
        public SearchSort Sort { get; set; }

        [RequestProperty("sr_detail")]
        public bool? SrDetail { get; set; }

        [RequestProperty("syntax")]
        public Syntax? Syntax { get; set; }

        [RequestProperty("t")]
        public TimeSort TimeSort { get; set; } = TimeSort.All;

        [RequestProperty("type")]
        [CommaDelimited]
        public ResultType? Type { get; set; }
    }
}
