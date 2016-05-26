using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Reddit.Net.Things;

namespace Reddit.Net.Requests
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
