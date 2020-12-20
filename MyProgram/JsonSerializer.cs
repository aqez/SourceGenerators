using System;
using System.Reflection;
using System.Text;

namespace MyProgram
{
    public class JsonSerializer
    {
        public string Serialize<T>(T obj)
        {
            return Serialize(obj, typeof(T));
        }

        private string Serialize(object obj, Type type)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("{ ");

            PropertyInfo[] propertyInfos = type.GetProperties();

            sb.Append($"\"{propertyInfos[0].Name}\" : {GetValueString(propertyInfos[0], obj)}");
            for (int i = 1; i < propertyInfos.Length; i++)
            {
                sb.Append($", \"{propertyInfos[i].Name}\" : {GetValueString(propertyInfos[i], obj)}");
            }

            sb.Append(" }");

            return sb.ToString();
        }

        private string GetValueString<T>(PropertyInfo propertyInfo, T obj)
        {
            object value = propertyInfo.GetValue(obj);

            if (value == null)
            {
                return "null";
            }

            if (propertyInfo.PropertyType == typeof(string))
            {
                return $"\"{value}\"";
            }

            return value.ToString();
        }
    }
}
