using System;
using System.Reflection;
using nVentive.Umbrella.Contracts;

namespace nVentive.Umbrella.Reflection
{
    public class BindingContract : IContract
    {
        internal static readonly BindingContract Default;

        internal static readonly BindingContract DefaultIgnoreCase;

        public static BindingFlags DefaultBindingFlags = BindingFlags.DeclaredOnly | BindingFlags.Static |
                                                         BindingFlags.Instance | BindingFlags.Public |
                                                         BindingFlags.NonPublic;

        public static BindingFlags DefaultBindingFlagsIgnoreCase = DefaultBindingFlags | BindingFlags.IgnoreCase;

        static BindingContract()
        {
             Default = new BindingContract(DefaultBindingFlags);
             DefaultIgnoreCase = new BindingContract(DefaultBindingFlagsIgnoreCase);
        }

        public BindingContract()
            : this(DefaultBindingFlags)
        {
        }

        public BindingContract(BindingFlags bindingFlags)
            : this(bindingFlags, null)
        {
        }

        public BindingContract(BindingFlags bindingFlags, Type[] types)
            : this(MemberTypes.All, bindingFlags, null, types, BindingBehavior.All)
        {
        }

        public BindingContract(MemberTypes memberType, BindingFlags bindingFlags, Type returnType, Type[] types,
                               BindingBehavior behavior)
        {
            MemberType = memberType;
            BindingFlags = bindingFlags;
            ReturnType = returnType;
            Types = types;
            Behavior = behavior;
        }

        public MemberTypes MemberType { get; set; }

        public BindingFlags BindingFlags { get; set; }

        public Type ReturnType { get; set; }

        public Type[] SafeTypes
        {
            get { return Types ?? Type.EmptyTypes; }
        }

        public Type[] Types { get; set; }

        public BindingBehavior Behavior { get; set; }
    }
}