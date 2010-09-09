using System;
using System.Reflection;
using nVentive.Umbrella.Extensions;

namespace nVentive.Umbrella.Reflection
{
    public class EventDescriptor : MemberDescriptor<EventInfo>, IEventDescriptor
    {
        public EventDescriptor(EventInfo eventInfo)
            : base(eventInfo)
        {
        }

        #region IEventDescriptor Members

        public override Type Type
        {
            get { return MemberInfo.EventHandlerType; }
        }

        public override bool IsStatic
        {
            get { return Add.IsStatic; }
        }

        public IMethodDescriptor Add
        {
            get { return Sources.Get("Add", () => (IMethodDescriptor) MemberInfo.GetAddMethod(true).GetDescriptor()); }
        }

        public IMethodDescriptor Remove
        {
            get { return Sources.Get("Remove", () => (IMethodDescriptor) MemberInfo.GetRemoveMethod(true).GetDescriptor()); }
        }

        #endregion
    }
}