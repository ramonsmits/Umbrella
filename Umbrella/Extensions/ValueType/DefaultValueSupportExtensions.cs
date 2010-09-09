using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nVentive.Umbrella.Extensions.ValueType
{
    public class DefaultValueSupportExtensions : IValueSupportExtensions
    {
        #region IValueSupportExtensions Members

        public virtual T And<T>(T lhs, T rhs) where T : struct
        {
        }

        public virtual T Or<T>(T lhs, T rhs) where T : struct
        {
        }

        public virtual T Xor<T>(T lhs, T rhs) where T : struct
        {
        }

        public virtual T Add<T>(T lhs, T rhs) where T : struct
        {
        }

        public virtual T Substract<T>(T lhs, T rhs) where T : struct
        {
        }

        public virtual T Multiply<T>(T lhs, T rhs) where T : struct
        {
        }

        public virtual T Divide<T>(T lhs, T rhs) where T : struct
        {
        }

        public virtual T Negate<T>(T instance) where T : struct
        {
        }

        public virtual T Not<T>(T instance) where T : struct
        {
        }

        public virtual bool ContainsAny<T>(T lhs, T rhs) where T : struct
        {
        }

        public virtual bool ContainsAll<T>(T lhs, T rhs) where T : struct
        {
        }

        #endregion
    }
}
