using System.Runtime.Serialization;

namespace RedditNet.Things
{
    public enum SubmissionType
    {
        [EnumMember(Value = "any")]
        Any,
        [EnumMember(Value = "link")]
        Link,
        [EnumMember(Value = "self")]
        Self
    }
}
