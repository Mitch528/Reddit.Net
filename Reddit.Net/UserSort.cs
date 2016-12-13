using System.Runtime.Serialization;

namespace RedditNet
{
    public enum UserSort
    {
        [EnumMember(Value = "hot")]
        Hot,
        [EnumMember(Value = "new")]
        New,
        [EnumMember(Value = "top")]
        Top,
        [EnumMember(Value = "controversial")]
        Controversial
    }
}
