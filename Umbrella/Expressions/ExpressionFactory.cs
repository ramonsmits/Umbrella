using System;
using System.Linq.Expressions;

namespace nVentive.Umbrella.Expressions
{
    public static class ExpressionFactory
    {
        public static Expression<Func<T, bool>> PropertyEqualConstant<T>(string propertyName, object value)
        {
            var parameter = Expression.Parameter(typeof (T), "item");

            var property = Expression.Property(parameter, propertyName);
            var constant = Expression.Constant(value);

            var body = Expression.Equal(property, constant);

            return Expression.Lambda<Func<T, bool>>(body, parameter);
        }
    }
}