using System;

namespace nVentive.Umbrella.Extensions.ValueType
{
    public class ValueSupport<T> : IValueSupport<T>
    {
        #region IValueSupport<T> Members

        public T And(T lhs, T rhs)
        {
            return CoreAnd(lhs, rhs);
        }

        public T Or(T lhs, T rhs)
        {
            return CoreOr(lhs, rhs);
        }

        public T Xor(T lhs, T rhs)
        {
            return CoreXor(lhs, rhs);
        }

        public T Add(T lhs, T rhs)
        {
            return CoreAdd(lhs, rhs);
        }

        public T Substract(T lhs, T rhs)
        {
            return CoreSubstract(lhs, rhs);
        }

        public T Multiply(T lhs, T rhs)
        {
            return CoreMultiply(lhs, rhs);
        }

        public T Divide(T lhs, T rhs)
        {
            return CoreDivide(lhs, rhs);
        }

        public T Negate(T instance)
        {
            return CoreNegate(instance);
        }

        public T Not(T instance)
        {
            return CoreNot(instance);
        }

        object IValueSupport.And(object lhs, object rhs)
        {
            return CoreAnd((T) lhs, (T) rhs);
        }

        object IValueSupport.Or(object lhs, object rhs)
        {
            return CoreOr((T) lhs, (T) rhs);
        }

        object IValueSupport.Xor(object lhs, object rhs)
        {
            return CoreXor((T) lhs, (T) rhs);
        }

        object IValueSupport.Add(object lhs, object rhs)
        {
            return CoreAdd((T) lhs, (T) rhs);
        }

        object IValueSupport.Substract(object lhs, object rhs)
        {
            return CoreSubstract((T) lhs, (T) rhs);
        }

        object IValueSupport.Multiply(object lhs, object rhs)
        {
            return CoreMultiply((T) lhs, (T) rhs);
        }

        object IValueSupport.Divide(object lhs, object rhs)
        {
            return CoreDivide((T) lhs, (T) rhs);
        }

        object IValueSupport.Negate(object instance)
        {
            return CoreNegate((T) instance);
        }

        object IValueSupport.Not(object instance)
        {
            return CoreNot((T) instance);
        }

        #endregion

        protected virtual T CoreAnd(T lhs, T rhs)
        {
            throw new InvalidOperationException();
        }

        protected virtual T CoreOr(T lhs, T rhs)
        {
            throw new InvalidOperationException();
        }

        protected virtual T CoreXor(T lhs, T rhs)
        {
            throw new InvalidOperationException();
        }

        protected virtual T CoreAdd(T lhs, T rhs)
        {
            throw new InvalidOperationException();
        }

        protected virtual T CoreSubstract(T lhs, T rhs)
        {
            throw new InvalidOperationException();
        }

        protected virtual T CoreMultiply(T lhs, T rhs)
        {
            throw new InvalidOperationException();
        }

        protected virtual T CoreDivide(T lhs, T rhs)
        {
            throw new InvalidOperationException();
        }

        protected virtual T CoreNegate(T instance)
        {
            throw new InvalidOperationException();
        }

        protected virtual T CoreNot(T instance)
        {
            throw new InvalidOperationException();
        }
    }
}