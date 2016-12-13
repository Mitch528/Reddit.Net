using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace RedditNet.Extensions
{
    public static class EnumExtensions
    {
        public static List<string> EnumToList(this Type enumType, int value)
        {
            TypeInfo tInfo = enumType.GetTypeInfo();
            if (!tInfo.IsEnum)
                throw new InvalidOperationException();

            var retVals = new List<string>();
            foreach (int val in Enum.GetValues(enumType))
            {
                if ((value & val) == val)
                {
                    string name = Enum.GetName(enumType, val);

                    MemberInfo enumMemberInfo = tInfo.DeclaredMembers.FirstOrDefault(p => p.Name == name);

                    var enumMember = enumMemberInfo.GetCustomAttribute<EnumMemberAttribute>();

                    retVals.Add(enumMember != null ? enumMember.Value : name);
                }
            }

            return retVals;
        }

        public static string EnumToCommaDelimitedString(this Type enumType, int value)
        {
            return string.Join(",", enumType.EnumToList(value));
        }

        public static string GetEnumMemberValue(this Type enumType, int value)
        {
            TypeInfo tInfo = enumType.GetTypeInfo();
            if (!tInfo.IsEnum)
                throw new InvalidOperationException();

            string name = Enum.GetName(enumType, value);
            MemberInfo enumMemberInfo = tInfo.DeclaredMembers.FirstOrDefault(p => p.Name == name);

            var enumMember = enumMemberInfo?.GetCustomAttribute<EnumMemberAttribute>();

            return enumMember?.Value;
        }
    }
}
