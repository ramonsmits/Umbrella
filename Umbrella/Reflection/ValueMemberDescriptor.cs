using System;
using System.Reflection;

namespace nVentive.Umbrella.Reflection
{
    public abstract class ValueMemberDescriptor<TMemberInfo> : MemberDescriptor<TMemberInfo>, IValueMemberDescriptor
        where TMemberInfo : MemberInfo
    {
        public ValueMemberDescriptor(TMemberInfo memberInfo)
            : base(memberInfo)
        {
        }

        #region IValueMemberDescriptor Members

        public virtual object GetValue(object instance)
        {
            throw new NotImplementedException();
        }

        public virtual void SetValue(object instance, object value)
        {
            throw new NotImplementedException();
        }

        public virtual Action<object, object> ToCompiledSetValue()
        {
            throw new NotImplementedException();
        }

        public virtual Action<object, object> ToCompiledSetValue(bool strict)
        {
            throw new NotImplementedException();
        }

        public virtual Func<object, object> ToCompiledGetValue()
        {
            throw new NotImplementedException();
        }

        public virtual Func<object, object> ToCompiledGetValue(bool strict)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}