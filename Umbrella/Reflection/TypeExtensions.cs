using System;
using System.Linq;
using System.Reflection;
using nVentive.Umbrella.Extensions.ValueType;
using nVentive.Umbrella.Reflection;
using System.Linq.Expressions;

namespace nVentive.Umbrella.Extensions
{
    public static class TypeExtensions
    {
        public static object New(this Type type, params object[] args)
        {
            return Activator.CreateInstance(type, args);
        }

        public static T New<T>(this Type type, params object[] args)
        {
            return (T) New(type, args);
        }

        public static bool Is<T>(this Type type)
        {
            return typeof (T).IsAssignableFrom(type);
        }

        public static MemberInfo GetMemberInfo(this Type type, string memberName)
        {
            return GetMemberInfo(type, memberName, BindingContract.Default);
        }

        public static MemberInfo GetMemberInfo(this Type type, string memberName, BindingContract contract)
        {
            var mi = FindMemberInfo(type, memberName, contract);

            return mi.Validation().Found();
        }

        public static MemberInfo FindMemberInfo(this Type type, string memberName)
        {
            return FindMemberInfo(type, memberName, BindingContract.Default);
        }

        public static MemberInfo FindMemberInfo(this Type type, string memberName, BindingContract contract)
        {
            var mi = FindInheritedMember(type, memberName, contract);

            if (mi == null &&
                contract.Behavior.ContainsAll(BindingBehavior.Interface))
            {
                foreach (var interfaceType in type.GetInterfaces())
                {
                    mi = FindInheritedMember(interfaceType, memberName, contract);

                    if (mi != null)
                    {
                        break;
                    }
                }
            }

            return mi;
        }

        public static TAttribute FindAttribute<TAttribute>(this Type type)
            where TAttribute : Attribute
        {
            return type.GetCustomAttributes(typeof (TAttribute), true).FirstOrDefault() as TAttribute;
        }

        public static MemberInfo FindInheritedMember(Type type, string memberName, BindingContract contract)
        {
            MemberInfo mi = null;

            while (type != null)
            {
                mi = FindMember(type, memberName, contract);

                if (mi != null ||
                    !contract.Behavior.ContainsAll(BindingBehavior.Inherited))
                {
                    break;
                }

                type = type.BaseType;
            }

            return mi;
        }

        public static MemberInfo FindMember(Type type, string memberName, BindingContract contract)
        {
            MemberInfo memberInfo;

            if (contract.MemberType.ContainsAll(MemberTypes.Property))
            {
                memberInfo = type.GetProperty(memberName, contract.BindingFlags, null, contract.ReturnType,
                                              contract.SafeTypes, null);

                if (memberInfo != null)
                {
                    return memberInfo;
                }
            }

            if (contract.MemberType.ContainsAll(MemberTypes.Event))
            {
                memberInfo = type.GetEvent(memberName, contract.BindingFlags);

                if (memberInfo != null)
                {
                    return memberInfo;
                }
            }

            if (contract.MemberType.ContainsAll(MemberTypes.Field))
            {
                memberInfo = type.GetField(memberName, contract.BindingFlags);

                if (memberInfo != null)
                {
                    return memberInfo;
                }
            }

            if (contract.MemberType.ContainsAll(MemberTypes.Method))
            {
                memberInfo = contract.Types == null
                                 ? type.GetMethod(memberName, contract.BindingFlags)
                                 : type.GetMethod(memberName, contract.BindingFlags, null, contract.Types, null);

                if (memberInfo != null)
                {
                    return memberInfo;
                }
            }

            if (contract.MemberType.ContainsAll(MemberTypes.NestedType))
            {
                memberInfo = type.GetNestedType(memberName, contract.BindingFlags);

                if (memberInfo != null)
                {
                    return memberInfo;
                }
            }

            return null;
        }
    }
}
