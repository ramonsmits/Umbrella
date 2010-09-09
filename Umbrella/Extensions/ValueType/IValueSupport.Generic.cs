namespace nVentive.Umbrella.Extensions.ValueType
{
    public interface IValueSupport<T> : IValueSupport
    {
        T And(T lhs, T rhs);
        T Or(T lhs, T rhs);
        T Xor(T lhs, T rhs);
        T Add(T lhs, T rhs);
        T Substract(T lhs, T rhs);
        T Multiply(T lhs, T rhs);
        T Divide(T lhs, T rhs);
        T Negate(T instance);
        T Not(T instance);
    }
}