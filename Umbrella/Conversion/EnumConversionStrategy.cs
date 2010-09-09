using System;
using System.ComponentModel;
using System.Reflection;
using nVentive.Umbrella.Extensions;

namespace nVentive.Umbrella.Conversion
{
    public class EnumConversionStrategy : IConversionStrategy
    {
        #region IConversionStrategy Members

        public bool CanConvert(object value, Type type)
        {
            if (type.IsEnum)
            {
                // NOTE: To be tested
                var text = FindValue(type, value as string ?? value.ToString());

                return text != null;
            }
            
            //TODO Support value == null
            return value != null &&
                   value.GetType().IsEnum &&
                   type == typeof (string);
        }

        public object Convert(object value, Type type)
        {
            if (type.IsEnum)
            {
                // NOTE: To be tested
                var text = FindValue(type, value as string ?? value.ToString());

                return Enum.Parse(type, text, false);
            }
            else
            {
                var text = value.ToString();

                var attribute = value.Reflection().GetDescriptor(text).FindAttribute<DescriptionAttribute>();

                return attribute == null ? text : attribute.Description;
            }
        }

        #endregion

        protected virtual string FindValue(Type enumType, string text)
        {
            FieldInfo unkwknownFieldInfo = null;

            foreach (var field in enumType.GetFields())
            {
                if (field.Name == text)
                {
                    return text;
                }

                var attribute = field.GetDescriptor().FindAttribute<DescriptionAttribute>();

                if (attribute == null) continue;

                if (attribute.Description == text)
                {
                    return field.Name;
                }
                
                if (attribute.Description == "?")
                {
                    unkwknownFieldInfo = field;
                }
            }

            return unkwknownFieldInfo == null ? null : unkwknownFieldInfo.Name;
        }
    }
}