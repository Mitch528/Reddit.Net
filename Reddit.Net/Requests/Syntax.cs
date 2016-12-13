using System.Runtime.Serialization;

namespace RedditNet.Requests
{
    public enum Syntax
    {
        [EnumMember(Value = "cloudsearch")]
        CloudSearch,
        [EnumMember(Value = "lucene")]
        Lucene,
        [EnumMember(Value = "plain")]
        Plain
    }
}
