using System;
using System.Reflection;
using nVentive.Umbrella.Containers;
using nVentive.Umbrella.Extensions;

namespace nVentive.Umbrella.Reflection
{
    public abstract class MemberDescriptor<TMemberInfo> : Container, IMemberDescriptor
        where TMemberInfo : MemberInfo
    {
        private readonly TMemberInfo memberInfo;


        // TODO: protected constructor?
        public MemberDescriptor(TMemberInfo memberInfo)
        {
            this.memberInfo = memberInfo.Validation().NotNull("memberInfo");
        }

        public TMemberInfo MemberInfo
        {
            get { return memberInfo; }
        }

        #region IMemberDescriptor Members

        public abstract Type Type { get; }

        MemberInfo IMemberDescriptor.MemberInfo
        {
            get { return memberInfo; }
        }

        public virtual bool IsStatic
        {
            get { return false; }
        }

        public virtual bool IsInstance
        {
            get { return !IsStatic; }
        }

        public virtual bool IsGeneric
        {
            get { return false; }
        }

        public virtual bool IsOpen
        {
            get { return false; }
        }

        public virtual bool IsClosed
        {
            get { return !IsOpen; }
        }

        public virtual IMemberDescriptor Open()
        {
            throw new InvalidOperationException();
        }

        public virtual IMemberDescriptor Close(params Type[] types)
        {
            throw new InvalidOperationException();
        }

        #endregion
    }
}