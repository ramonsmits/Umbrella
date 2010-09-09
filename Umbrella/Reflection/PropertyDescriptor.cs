using System;
using System.Reflection;

namespace nVentive.Umbrella.Reflection
{
    public class PropertyDescriptor : ValueMemberDescriptor<PropertyInfo>
    {
        public PropertyDescriptor(PropertyInfo pi)
            : base(pi)
        {
        }

        public override Type Type
        {
            get { return MemberInfo.PropertyType; }
        }

        public override bool IsStatic
        {
            get { return MemberInfo.GetGetMethod(true).IsStatic; }
        }

        public override object GetValue(object instance)
        {
            return MemberInfo.GetValue(instance, null);
        }

        public override void SetValue(object instance, object value)
        {
            MemberInfo.SetValue(instance, value, null);
        }

        public override Func<object, object> ToCompiledGetValue()
        {
            return instance => MemberInfo.GetValue(instance, null);
        }

        public override Func<object, object> ToCompiledGetValue(bool strict)
        {
            return instance => MemberInfo.GetValue(instance, null);
        }

        public override Action<object, object> ToCompiledSetValue()
        {
            return (instance, value) => MemberInfo.SetValue(instance, value, null);
        }

        public override Action<object, object> ToCompiledSetValue(bool strict)
        {
            return (instance, value) => MemberInfo.SetValue(instance, value, null);
        }
    }
}