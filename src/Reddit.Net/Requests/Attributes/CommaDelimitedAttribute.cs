using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reddit.Net.Requests.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class CommaDelimitedAttribute : Attribute
    {
    }
}
