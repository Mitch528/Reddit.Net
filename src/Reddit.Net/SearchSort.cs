using System.Runtime.Serialization;

namespace Reddit.Net
{
    public enum SearchSort
    {
        [EnumMember(Value = "relevance")]
        Relevance,
        [EnumMember(Value = "hot")]
        Hot,
        [EnumMember(Value = "top")]
        Top,
        [EnumMember(Value = "new")]
        New,
        [EnumMember(Value = "comments")]
        Comments
    }
}
