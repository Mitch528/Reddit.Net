using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Reddit.Net.Things
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
