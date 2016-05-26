using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Reddit.Net.Requests
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
