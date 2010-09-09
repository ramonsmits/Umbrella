using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nVentive.Umbrella.Extensions.ValueType
{
    public interface IValueSupportExtensions
    {
        T And<T>(T lhs, T rhs)
            where T : struct;

        T Or<T>(T lhs, T rhs)
            where T : struct;

        T Xor<T>(T lhs, T rhs)
            where T : struct;

        T Add<T>(T lhs, T rhs)
            where T : struct;

        T Substract<T>(T lhs, T rhs)
            where T : struct;

        T Multiply<T>(T lhs, T rhs)
            where T : struct;

        T Divide<T>(T lhs, T rhs)
            where T : struct;

        T Negate<T>(T instance)
            where T : struct;

        T Not<T>(T instance)
            where T : struct;

        bool ContainsAny<T>(T lhs, T rhs)
            where T : struct;

        bool ContainsAll<T>(T lhs, T rhs)
            where T : struct;
    }
}
