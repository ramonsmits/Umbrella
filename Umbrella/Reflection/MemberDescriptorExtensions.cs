using System;
using System.Linq;
using nVentive.Umbrella.Reflection;

namespace nVentive.Umbrella.Extensions
{
    //TODO Use Extensions Pattern or move to ReflectionExtensions. Or maybe MemberInfoExtensions directly.
    public static class MemberDescriptorExtensions
    {
        public static T FindAttribute<T>(this IMemberDescriptor descriptor)
            where T : Attribute
        {
            var attributes = descriptor.MemberInfo.GetCustomAttributes(typeof (T), true);
            return attributes.FirstOrDefault() as T;
        }
    }
}