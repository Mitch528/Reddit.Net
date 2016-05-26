using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Reddit.Net
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
