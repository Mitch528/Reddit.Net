using System.Runtime.Serialization;

namespace RedditNet.Things
{
    public enum SubredditType
    {
        [EnumMember(Value = "public")]
        Public,
        [EnumMember(Value = "private")]
        Private,
        [EnumMember(Value = "restricted")]
        Restricted,
        [EnumMember(Value = "gold_restricted")]
        GoldRestricted,
        [EnumMember(Value = "archived")]
        Archived
    }
}
