using System;

namespace RedditNet
{
    public class RedditApiException : Exception
    {
        public RedditApiException(string message) : base(message)
        {
        }
    }
}
