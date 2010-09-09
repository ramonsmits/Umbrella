using System;
using System.Reflection;

namespace nVentive.Umbrella.Reflection
{
    public interface IMemberDescriptor
    {
        Type Type { get; }

        MemberInfo MemberInfo { get; }

        bool IsStatic { get; }
        bool IsInstance { get; }

        bool IsGeneric { get; }

        bool IsOpen { get; }
        bool IsClosed { get; }

        IMemberDescriptor Open();
        IMemberDescriptor Close(params Type[] types);
    }
}