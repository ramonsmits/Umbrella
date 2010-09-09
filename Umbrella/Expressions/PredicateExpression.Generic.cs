using System;
using System.Linq.Expressions;
using nVentive.Umbrella.Extensions;

namespace nVentive.Umbrella.Expressions
{
    public class PredicateExpression<T>
    {
        private readonly Expression<Func<T, bool>> expression;

        public PredicateExpression(Expression<Func<T, bool>> expression)
        {
            //TODO Could make sure the parameter is "item"
            this.expression = expression;
        }

        public Expression<Func<T, bool>> Expression
        {
            get { return expression; }
        }

        public static implicit operator Expression<Func<T, bool>>(PredicateExpression<T> proxy)
        {
            return proxy.Expression;
        }

        public static implicit operator PredicateExpression<T>(Expression<Func<T, bool>> expression)
        {
            return new PredicateExpression<T>(expression);
        }

        public static implicit operator Func<T, bool>(PredicateExpression<T> proxy)
        {
            return proxy.Expression.Compile();
        }

        public static bool operator true(PredicateExpression<T> expression)
        {
            return false;
        }

        public static bool operator false(PredicateExpression<T> expression)
        {
            return false;
        }

        public static PredicateExpression<T> operator &(PredicateExpression<T> lhs, PredicateExpression<T> rhs)
        {
            if (lhs == null)
            {
                return rhs;
            }

            if (rhs == null)
            {
                return lhs;
            }

            return lhs.Expression.And(rhs.Expression);
        }

        public static PredicateExpression<T> operator |(PredicateExpression<T> lhs, PredicateExpression<T> rhs)
        {
            if (lhs == null)
            {
                return rhs;
            }

            if (rhs == null)
            {
                return lhs;
            }

            return lhs.Expression.Or(rhs.Expression);
        }
    }
}