using System;
using System.Linq.Expressions;
using nVentive.Umbrella.Extensions;

namespace nVentive.Umbrella.Expressions
{
    public class PredicateExpression
    {
        private readonly Expression<Func<bool>> expression;

        public PredicateExpression(Expression<Func<bool>> expression)
        {
            //TODO Could make sure the parameter is "item"
            this.expression = expression;
        }

        public Expression<Func<bool>> Expression
        {
            get { return expression; }
        }

        public static implicit operator Expression<Func<bool>>(PredicateExpression proxy)
        {
            return proxy.Expression;
        }

        public static implicit operator PredicateExpression(Expression<Func<bool>> expression)
        {
            return new PredicateExpression(expression);
        }

        public static implicit operator Func<bool>(PredicateExpression proxy)
        {
            return proxy.Expression.Compile();
        }

        public static bool operator true(PredicateExpression expression)
        {
            return false;
        }

        public static bool operator false(PredicateExpression expression)
        {
            return false;
        }

        public static PredicateExpression operator &(PredicateExpression lhs, PredicateExpression rhs)
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

        public static PredicateExpression operator |(PredicateExpression lhs, PredicateExpression rhs)
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