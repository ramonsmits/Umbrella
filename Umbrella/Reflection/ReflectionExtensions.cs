using System;
using System.Collections.Generic;
using System.Reflection;
using nVentive.Umbrella.Reflection;
using System.Linq.Expressions;

namespace nVentive.Umbrella.Extensions
{
    public static class ReflectionExtensions
    {
        public static IReflectionExtensions Extensions
        {
            get { return ExtensionsProvider.Get<IReflectionExtensions, DefaultReflectionExtensions>(); }
        }

        public static object Get(this IReflectionExtensionPoint extensionPoint, string memberName)
        {
            return Extensions.Get(extensionPoint, memberName);
        }

        public static T Get<T>(this IReflectionExtensionPoint extensionPoint, string memberName)
        {
            return Extensions.Get<T>(extensionPoint, memberName);
        }

        public static T Get<T,U>(this IReflectionExtensionPoint<U> extensionPoint, string memberName)
        {
            return Extensions.Get<T>(extensionPoint, memberName);
        }

        public static object Get(this IReflectionExtensionPoint extensionPoint, IEnumerable<string> memberNames)
        {
            return Extensions.Get(extensionPoint, memberNames);
        }
        
        public static T Get<T>(this IReflectionExtensionPoint extensionPoint, IEnumerable<string> memberNames)
        {
            return Extensions.Get<T>(extensionPoint, memberNames);
        }

        public static T Get<T,U>(this IReflectionExtensionPoint<U> extensionPoint, IEnumerable<string> memberNames)
        {
            return Extensions.Get<T>(extensionPoint, memberNames);
        }

        public static object Get(this IReflectionExtensionPoint extensionPoint,
                                 IEnumerable<IValueMemberDescriptor> descriptors)
        {
            return Extensions.Get(extensionPoint, descriptors);
        }

        public static T Get<T>(this IReflectionExtensionPoint extensionPoint,
                               IEnumerable<IValueMemberDescriptor> descriptors)
        {
            return Extensions.Get<T>(extensionPoint, descriptors);
        }

        public static T Get<T,U>(this IReflectionExtensionPoint<U> extensionPoint,
                               IEnumerable<IValueMemberDescriptor> descriptors)
        {
            return Extensions.Get<T>(extensionPoint, descriptors);
        }

        public static void Set<T>(this IReflectionExtensionPoint extensionPoint, string memberName, T value)
        {
            Extensions.Set(extensionPoint, memberName, value);
        }

        public static void Set<T>(this IReflectionExtensionPoint extensionPoint, IEnumerable<string> memberNames,
                                  T value)
        {
            Extensions.Set(extensionPoint, memberNames, value);
        }

        public static void Set<T,U>(this IReflectionExtensionPoint<U> extensionPoint, IEnumerable<string> memberNames,
                                  T value)
        {
            Extensions.Set(extensionPoint, memberNames, value);
        }

        public static void Set<T>(this IReflectionExtensionPoint extensionPoint,
                                  IEnumerable<IValueMemberDescriptor> descriptors, T value)
        {
            Extensions.Set(extensionPoint, descriptors, value);
        }

        public static void Set<T,U>(this IReflectionExtensionPoint<U> extensionPoint,
                                  IEnumerable<IValueMemberDescriptor> descriptors, T value)
        {
            Extensions.Set(extensionPoint, descriptors, value);
        }

        public static IEnumerable<IValueMemberDescriptor> GetValueDescriptors(
            this IReflectionExtensionPoint extensionPoint, IEnumerable<string> memberNames)
        {
            return Extensions.GetValueDescriptors(extensionPoint, memberNames);
        }

        public static IEnumerable<IMemberDescriptor> GetDescriptors(this IReflectionExtensionPoint extensionPoint,
                                                                    IEnumerable<string> memberNames)
        {
            return Extensions.GetDescriptors(extensionPoint, memberNames);
        }

        public static IMemberDescriptor GetDescriptor(this IReflectionExtensionPoint extensionPoint)
        {
            return Extensions.GetDescriptor(extensionPoint);
        }

        public static IMemberDescriptor GetDescriptor(this IMemberDescriptor descriptor, string memberName)
        {
            return Extensions.GetDescriptor(descriptor, memberName);
        }

        public static IMemberDescriptor FindDescriptor(this IMemberDescriptor descriptor, string memberName)
        {
            return Extensions.FindDescriptor(descriptor, memberName);
        }

        public static IValueMemberDescriptor GetValueDescriptor(this IReflectionExtensionPoint extensionPoint,
                                                                string memberName)
        {
            return Extensions.GetValueDescriptor(extensionPoint, memberName);
        }

        public static IValueMemberDescriptor FindValueDescriptor(this IReflectionExtensionPoint extensionPoint,
                                                                 string memberName)
        {
            return Extensions.FindValueDescriptor(extensionPoint, memberName);
        }

        public static IMemberDescriptor GetDescriptor(this IReflectionExtensionPoint extensionPoint, string memberName)
        {
            return Extensions.GetDescriptor(extensionPoint, memberName);
        }

        public static IMemberDescriptor GetDescriptor<TArg1>(this IReflectionExtensionPoint<TArg1> extensionPoint, Expression<Action<TArg1>> func)
        {
            return Extensions.GetDescriptor(extensionPoint, func);
        }

        public static IMemberDescriptor GetDescriptor<TArg1, TResult>(this IReflectionExtensionPoint<TArg1> extensionPoint, Expression<Func<TArg1, TResult>> func)
        {
            return Extensions.GetDescriptor(extensionPoint, func);
        }

        public static IMemberDescriptor FindDescriptor(this IReflectionExtensionPoint extensionPoint, string memberName)
        {
            return Extensions.FindDescriptor(extensionPoint, memberName);
        }

        public static IMemberDescriptor FindDescriptor(this IReflectionExtensionPoint extensionPoint, string memberName,
                                                       BindingContract contract)
        {
            return Extensions.FindDescriptor(extensionPoint, memberName, contract);
        }

        public static IReflectionExtensionPoint Reflection(this Type type)
        {
            return Extensions.Reflection(type);
        }

        public static IReflectionExtensionPoint<T> Reflection<T>(this T instance)
        {
            return Extensions.Reflection(instance);
        }

        public static IDisposable Observe(this IEventDescriptor descriptor, object publisher, object observer,
                                          string methodName)
        {
            return Extensions.Observe(descriptor, publisher, observer, methodName);
        }

        public static IMemberDescriptor GetDescriptor(this MemberInfo mi)
        {
            return Extensions.GetDescriptor(mi);
        }
    }
}
