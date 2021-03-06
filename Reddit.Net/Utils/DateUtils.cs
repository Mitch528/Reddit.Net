﻿using System;

namespace RedditNet.Utils
{
    public static class DateUtils
    {
        //http://stackoverflow.com/a/2883645/4254412
        public static DateTime FromUnixTime(long unixTime)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddSeconds(unixTime);
        }
    }
}
