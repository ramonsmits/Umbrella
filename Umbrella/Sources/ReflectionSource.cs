using System;
using nVentive.Umbrella.Extensions;
using nVentive.Umbrella.Reflection;

namespace nVentive.Umbrella.Sources
{
    public class ReflectionSource<T> : ISource<T>
    {
        private readonly IValueMemberDescriptor get;
        private readonly string getMemberName;
        private readonly object instance;
        private readonly IValueMemberDescriptor set;
        private readonly string setMemberName;
        private Type type; // TODO: type is not used outside constructor

        public ReflectionSource(Type type, string memberName)
        {
            this.type = type;

            getMemberName = setMemberName = memberName;

            get = set = type.Reflection().GetValueDescriptor(memberName);
        }

        public ReflectionSource(object instance, string memberName)
        {
            this.instance = instance;

            getMemberName = setMemberName = memberName;

            get = set = instance.Reflection().GetValueDescriptor(memberName);
        }

        public ReflectionSource(object instance, string getMemberName, string setMemberName)
        {
            this.instance = instance;

            this.getMemberName = getMemberName;
            this.setMemberName = setMemberName;

            get = instance.Reflection().GetValueDescriptor(getMemberName);
            set = instance.Reflection().GetValueDescriptor(setMemberName);
        }

        public string GetMemberName
        {
            get { return getMemberName; }
        }

        public string SetMemberName
        {
            get { return setMemberName; }
        }

        #region ISource<T> Members

        public T Value
        {
            get { return (T) get.GetValue(instance); }
            set { set.SetValue(instance, value); }
        }

        #endregion
    }
}