namespace nVentive.Umbrella.Extensions.ValueType
{
    public static class ValueSupportExtensions
    {
        public static T And<T>(this T lhs, T rhs)
            where T : struct
        {
            return ValueSupport.Get<T>().And(lhs, rhs);
        }

        public static T Or<T>(this T lhs, T rhs)
            where T : struct
        {
            return ValueSupport.Get<T>().Or(lhs, rhs);
        }

        public static T Xor<T>(this T lhs, T rhs)
            where T : struct
        {
            return ValueSupport.Get<T>().Xor(lhs, rhs);
        }

        public static T Add<T>(this T lhs, T rhs)
            where T : struct
        {
            return ValueSupport.Get<T>().Add(lhs, rhs);
        }

        public static T Substract<T>(this T lhs, T rhs)
            where T : struct
        {
            return ValueSupport.Get<T>().Substract(lhs, rhs);
        }

        public static T Multiply<T>(this T lhs, T rhs)
            where T : struct
        {
            return ValueSupport.Get<T>().Multiply(lhs, rhs);
        }

        public static T Divide<T>(this T lhs, T rhs)
            where T : struct
        {
            return ValueSupport.Get<T>().Divide(lhs, rhs);
        }

        public static T Negate<T>(this T instance)
            where T : struct
        {
            return ValueSupport.Get<T>().Negate(instance);
        }

        public static T Not<T>(this T instance)
            where T : struct
        {
            return ValueSupport.Get<T>().Not(instance);
        }

        public static bool ContainsAny<T>(this T lhs, T rhs)
            where T : struct
        {
            return !Equals(lhs.And(rhs), (T) (object) 0);
        }

        public static bool ContainsAll<T>(this T lhs, T rhs)
            where T : struct
        {
            return Equals(lhs.And(rhs), rhs);
        }
    }
}