using System;

namespace RedditNet.Requests.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class RequestPropertyAttribute : Attribute
    {
        public string Name { get; set; }

        public RequestPropertyAttribute(string name)
        {
            Name = name;
        }
    }
}
