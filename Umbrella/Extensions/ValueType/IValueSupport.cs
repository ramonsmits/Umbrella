namespace nVentive.Umbrella.Extensions.ValueType
{
    public interface IValueSupport
    {
        object And(object lhs, object rhs);
        object Or(object lhs, object rhs);
        object Xor(object lhs, object rhs);
        object Add(object lhs, object rhs);
        object Substract(object lhs, object rhs);
        object Multiply(object lhs, object rhs);
        object Divide(object lhs, object rhs);
        object Negate(object instance);
        object Not(object instance);
    }
}