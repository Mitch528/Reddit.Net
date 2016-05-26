using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Reddit.Net
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
