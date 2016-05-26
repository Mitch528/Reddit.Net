using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reddit.Net
{
    public class RedditApiException : Exception
    {
        public RedditApiException(string message) : base(message)
        {
        }
    }
}
