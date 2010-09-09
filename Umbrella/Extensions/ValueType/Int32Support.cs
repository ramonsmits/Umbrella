namespace nVentive.Umbrella.Extensions.ValueType
{
    public class Int32Support : ValueSupport<int>
    {
        protected override int CoreAnd(int lhs, int rhs)
        {
            return lhs & rhs;
        }

        protected override int CoreOr(int lhs, int rhs)
        {
            return lhs | rhs;
        }

        protected override int CoreXor(int lhs, int rhs)
        {
            return lhs ^ rhs;
        }

        protected override int CoreAdd(int lhs, int rhs)
        {
            return lhs + rhs;
        }

        protected override int CoreSubstract(int lhs, int rhs)
        {
            return lhs - rhs;
        }

        protected override int CoreMultiply(int lhs, int rhs)
        {
            return lhs*rhs;
        }

        protected override int CoreDivide(int lhs, int rhs)
        {
            return lhs/rhs;
        }

        protected override int CoreNegate(int instance)
        {
            return -instance;
        }

        protected override int CoreNot(int instance)
        {
            return ~instance;
        }
    }
}