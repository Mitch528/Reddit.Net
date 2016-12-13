using System;
using System.Collections.Generic;
using System.Reflection;
using RedditNet.Requests.Attributes;

namespace RedditNet.Extensions
{
    public static class RedditRequestExtensions
    {
        public static List<KeyValuePair<string, string>> ToKeyValuePairs(this object request)
        {
            var kvps = new List<KeyValuePair<string, string>>();

            Type rType = request.GetType();

            foreach (PropertyInfo pInfo in rType.GetRuntimeProperties())
            {
                Type type = pInfo.PropertyType;
                TypeInfo pTypeInfo = type.GetTypeInfo();

                RequestPropertyAttribute requestProperty = pInfo.GetCustomAttribute<RequestPropertyAttribute>();
                CommaDelimitedAttribute commaDelimited = pInfo.GetCustomAttribute<CommaDelimitedAttribute>();

                if (pTypeInfo.IsGenericType && pTypeInfo.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    type = Nullable.GetUnderlyingType(pInfo.PropertyType);
                    pTypeInfo = type.GetTypeInfo();
                }

                object value = pInfo.GetValue(request);

                if (value != null)
                {
                    if (pTypeInfo.IsEnum)
                    {
                        string name = Enum.GetName(type, value);

                        if (commaDelimited != null)
                            value = type.EnumToCommaDelimitedString((int)value);
                        else
                            value = type.GetEnumMemberValue((int)value) ?? name.ToLower();
                    }
                    else if (type == typeof(bool))
                    {
                        value = (bool)value ? "true" : "false";
                    }

                    kvps.Add(requestProperty != null
                        ? new KeyValuePair<string, string>(requestProperty.Name, value.ToString())
                        : new KeyValuePair<string, string>(pInfo.Name.ToLower(), value.ToString()));
                }
            }

            return kvps;
        }
    }
}
