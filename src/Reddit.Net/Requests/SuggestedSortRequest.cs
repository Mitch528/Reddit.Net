using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Reddit.Net.Requests.Attributes;

namespace Reddit.Net.Requests
{
    public class SuggestedSortRequest : RedditRequestBase
    {
        [RequestProperty("id")]
        public string Id { get; set; }

        [RequestProperty("sort")]
        public SuggestedSort Sort { get; set; }
    }

    public enum SuggestedSort
    {
        [EnumMember(Value = "")]
        Blank,
        [EnumMember(Value = "confidence")]
        Confidence,
        [EnumMember(Value = "top")]
        Top,
        [EnumMember(Value = "new")]
        New,
        [EnumMember(Value = "controversial")]
        Controversial,
        [EnumMember(Value = "old")]
        Old,
        [EnumMember(Value = "random")]
        Random,
        [EnumMember(Value = "qa")]
        Qa
    }
}
