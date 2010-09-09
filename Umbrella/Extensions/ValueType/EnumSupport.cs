using System;

namespace nVentive.Umbrella.Extensions.ValueType
{
    public class EnumSupport<T> : ValueSupport<T>
    {
        private readonly IValueSupport support;

        public EnumSupport()
        {
            var type = Enum.GetUnderlyingType(typeof (T));

            support = ValueSupport.Get(type);
        }

        protected override T CoreAnd(T lhs, T rhs)
        {
            return (T) support.And(lhs, rhs);
        }

        protected override T CoreXor(T lhs, T rhs)
        {
            return (T) support.Xor(lhs, rhs);
        }

        protected override T CoreAdd(T lhs, T rhs)
        {
            return CoreOr(lhs, rhs);
        }

        protected override T CoreSubstract(T lhs, T rhs)
        {
            return (T) support.And(lhs, support.Not(rhs));
        }

        protected override T CoreOr(T lhs, T rhs)
        {
            return (T) support.Or(lhs, rhs);
        }

        protected override T CoreNot(T instance)
        {
            return (T) support.Not(instance);
        }
    }
}