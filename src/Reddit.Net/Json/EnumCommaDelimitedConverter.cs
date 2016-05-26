using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Reddit.Net.Json
{
    public class EnumCommaDelimitedConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Type valType = value.GetType();
            TypeInfo tInfo = valType.GetTypeInfo();

            if (!tInfo.IsEnum)
                throw new InvalidOperationException();

            int intVal = (int)value;

            var retVals = new List<string>();
            foreach (int val in Enum.GetValues(valType))
            {
                if ((intVal & val) == val)
                {
                    string name = Enum.GetName(valType, val);

                    MemberInfo enumMemberInfo = tInfo.DeclaredMembers.FirstOrDefault(p => p.Name == name);

                    var enumMember = enumMemberInfo.GetCustomAttribute<EnumMemberAttribute>();

                    retVals.Add(enumMember != null ? enumMember.Value : name);
                }
            }

            writer.WriteValue(string.Join(",", retVals));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType.GetTypeInfo().IsEnum;
        }
    }
}
