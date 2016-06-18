using System.Runtime.Serialization;

namespace RedditNet
{
    public enum CommentSort
    {
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
