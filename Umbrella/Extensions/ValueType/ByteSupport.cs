namespace nVentive.Umbrella.Extensions.ValueType
{
    public class ByteSupport : ValueSupport<byte>
    {
        protected override byte CoreAnd(byte lhs, byte rhs)
        {
            return (byte) (lhs & rhs);
        }

        protected override byte CoreOr(byte lhs, byte rhs)
        {
            return (byte) (lhs | rhs);
        }

        protected override byte CoreNegate(byte instance)
        {
            return (byte) (-instance);
        }

        protected override byte CoreNot(byte instance)
        {
            return (byte) (~instance);
        }

        protected override byte CoreAdd(byte lhs, byte rhs)
        {
            return (byte) (lhs + rhs);
        }

        protected override byte CoreSubstract(byte lhs, byte rhs)
        {
            return (byte) (lhs - rhs);
        }

        protected override byte CoreMultiply(byte lhs, byte rhs)
        {
            return (byte) (lhs*rhs);
        }

        protected override byte CoreDivide(byte lhs, byte rhs)
        {
            return (byte) (lhs/rhs);
        }
    }
}