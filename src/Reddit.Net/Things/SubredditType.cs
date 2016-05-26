using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Reddit.Net.Things
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
