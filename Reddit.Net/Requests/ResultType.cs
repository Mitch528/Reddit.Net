using System;
using System.Runtime.Serialization;

namespace RedditNet.Requests
{
    [Flags]
    public enum ResultType
    {
        [EnumMember(Value = "sr")]
        Sr = 1 << 1,
        [EnumMember(Value = "link")]
        Link = 1 << 2
    }
}
