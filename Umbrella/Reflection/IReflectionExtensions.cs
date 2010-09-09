﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq.Expressions;

namespace nVentive.Umbrella.Reflection
{
    public interface IReflectionExtensions
    {
        IReflectionExtensionPoint Reflection(Type type);
        IReflectionExtensionPoint<T> Reflection<T>(T instance);

        object Get(IReflectionExtensionPoint extensionPoint, string memberName);
        T Get<T>(IReflectionExtensionPoint extensionPoint, string memberName);

        object Get(IReflectionExtensionPoint extensionPoint, IEnumerable<string> memberNames);
        T Get<T>(IReflectionExtensionPoint extensionPoint, IEnumerable<string> memberNames);

        object Get(IReflectionExtensionPoint extensionPoint, IEnumerable<IValueMemberDescriptor> descriptors);
        T Get<T>(IReflectionExtensionPoint extensionPoint, IEnumerable<IValueMemberDescriptor> descriptors);

        void Set<T>(IReflectionExtensionPoint extensionPoint, string memberName, T value);
        void Set<T>(IReflectionExtensionPoint extensionPoint, IEnumerable<string> memberNames, T value);
        void Set<T>(IReflectionExtensionPoint extensionPoint, IEnumerable<IValueMemberDescriptor> descriptors, T value);

        IEnumerable<IValueMemberDescriptor> GetValueDescriptors(IReflectionExtensionPoint extensionPoint,
                                                                IEnumerable<string> memberNames);

        IEnumerable<IMemberDescriptor> GetDescriptors(IReflectionExtensionPoint extensionPoint,
                                                      IEnumerable<string> memberNames);

        IMemberDescriptor GetDescriptor(IMemberDescriptor descriptor, string memberName);
        IMemberDescriptor GetDescriptor<TArg1>(IReflectionExtensionPoint<TArg1> extensionPoint, Expression<Action<TArg1>> func);
        IMemberDescriptor GetDescriptor<TArg1, TResult>(IReflectionExtensionPoint<TArg1> extensionPoint, Expression<Func<TArg1, TResult>> func);

        IMemberDescriptor FindDescriptor(IMemberDescriptor descriptor, string memberName);

        IValueMemberDescriptor GetValueDescriptor(IReflectionExtensionPoint extensionPoint, string memberName);
        IValueMemberDescriptor FindValueDescriptor(IReflectionExtensionPoint extensionPoint, string memberName);

        //TODO GetMethodDescriptor + FindMethodDescriptor
        IMemberDescriptor GetDescriptor(IReflectionExtensionPoint extensionPoint);
        IMemberDescriptor GetDescriptor(IReflectionExtensionPoint extensionPoint, string memberName);
        IMemberDescriptor FindDescriptor(IReflectionExtensionPoint extensionPoint, string memberName);

        IMemberDescriptor FindDescriptor(IReflectionExtensionPoint extensionPoint, string memberName,
                                         BindingContract contract);

        IMemberDescriptor GetDescriptor(MemberInfo mi);

        IDisposable Observe(IEventDescriptor descriptor, object publisher, object observer, string methodName);
    }
}