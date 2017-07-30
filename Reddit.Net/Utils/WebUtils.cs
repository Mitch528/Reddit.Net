using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace RedditNet.Utils
{
    public static class WebUtils
    {
        //http://stackoverflow.com/a/829138/4254412
        public static string ToQueryString(IEnumerable<KeyValuePair<string, string>> kvp)
        {
            if (kvp == null)
                return string.Empty;

            var array = (from t in kvp
                         select $"{WebUtility.UrlEncode(t.Key)}={WebUtility.UrlEncode(t.Value)}")
                .ToArray();

            return "?" + string.Join("&", array);
        }
    }
}
