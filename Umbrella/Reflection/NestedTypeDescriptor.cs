using System;

namespace nVentive.Umbrella.Reflection
{
    public class NestedTypeDescriptor : TypeDescriptor, IValueMemberDescriptor
    {
        public NestedTypeDescriptor(Type type)
            : base(type)
        {
        }

        #region IValueMemberDescriptor Members

        public override Type Type
        {
            get { return MemberInfo; }
        }

        public override bool IsStatic
        {
            get { return true; }
        }

        public override IMemberDescriptor Open()
        {
            return IsClosed ? new NestedTypeDescriptor(MemberInfo.GetGenericTypeDefinition()) : base.Open();
        }

        // TODO: params are ignored
        public override IMemberDescriptor Close(params Type[] types)
        {
            if (!IsOpen)
            {
                return base.Close(types);
            }
            var closedType = MemberInfo.MakeGenericType(types);

            return new NestedTypeDescriptor(closedType);
        }

        public object GetValue(object instance)
        {
            return instance;
        }

        public void SetValue(object instance, object value)
        {
            throw new NotImplementedException();
        }

        public Action<object, object> ToCompiledSetValue()
        {
            return SetValue;
        }

        public Action<object, object> ToCompiledSetValue(bool strict)
        {
            return SetValue;
        }

        public Func<object, object> ToCompiledGetValue()
        {
            return GetValue;
        }

        public Func<object, object> ToCompiledGetValue(bool strict)
        {
            return GetValue;
        }

        #endregion
    }
}