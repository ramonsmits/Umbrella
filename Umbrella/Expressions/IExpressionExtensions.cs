using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace nVentive.Umbrella.Expressions
{
    public interface IExpressionExtensions
    {
        //TODO Func<T, T, bool>, Func<T, T, T, bool>, ...
        Expression<Func<T, bool>> And<T>(Expression<Func<T, bool>> left, params Expression<Func<T, bool>>[] items);
        Expression<Func<T, bool>> Or<T>(Expression<Func<T, bool>> left, params Expression<Func<T, bool>>[] items);
        Expression<Func<T, bool>> Not<T>(Expression<Func<T, bool>> expression);
        //TODO Extend Expression.Compile().Invoke => Expression.Invoke
    }
}
