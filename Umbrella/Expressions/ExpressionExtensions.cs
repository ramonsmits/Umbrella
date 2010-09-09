using System;
using System.Linq;
using System.Linq.Expressions;

namespace nVentive.Umbrella.Extensions
{
    public static class ExpressionExtensions
    {
        public static string GetSelectedMemberName<T, TValue>(this Expression<Func<T, TValue>> selector)
        {
            if (selector == null)
            {
                return null;
            }
            else
            {
                var memberExpression = selector.Body as MemberExpression;

                return memberExpression.Member.Name;
            }
        }

        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> left,
                                                       params Expression<Func<T, bool>>[] items)
        {
            var result = left;

            items.ForEach(item => result = Binary(CompositionType.And, result, item));

            return result;
        }

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> left,
                                                      params Expression<Func<T, bool>>[] items)
        {
            var result = left;

            items.ForEach(item => result = Binary(CompositionType.Or, result, item));

            return result;
        }

        public static Expression<Func<T, bool>> Not<T>(this Expression<Func<T, bool>> expression)
        {
            return Expression.Lambda<Func<T, bool>>(Expression.Not(expression.Body), expression.Parameters);
        }

        public static Expression<Func<bool>> And(this Expression<Func<bool>> left, params Expression<Func<bool>>[] items)
        {
            var result = left;

            items.ForEach(item => result = Binary(CompositionType.And, result, item));

            return result;
        }

        public static Expression<Func<bool>> Or(this Expression<Func<bool>> left, params Expression<Func<bool>>[] items)
        {
            var result = left;

            items.ForEach(item => result = Binary(CompositionType.Or, result, item));

            return result;
        }

        public static Expression<Func<bool>> Not(this Expression<Func<bool>> expression)
        {
            return Expression.Lambda<Func<bool>>(Expression.Not(expression.Body), expression.Parameters);
        }

        private static Expression<T> Binary<T>(CompositionType type, Expression<T> left, Expression<T> right)
        {
            if (left == null)
            {
                return right;
            }

            if (right == null)
            {
                return left;
            }

            right = ReplaceParameters(left, right);

            var newBody = Binary(type, left.Body, right.Body);

            return Expression.Lambda<T>(newBody, left.Parameters);
        }

        private static Expression<T> ReplaceParameters<T>(Expression<T> source, Expression<T> target)
        {
            var editableTarget = target.Edit();

            editableTarget.Use(source.Parameters.Cast<Expression>());

            target = editableTarget.ToExpression();

            return target;
        }

        private static Expression Binary(CompositionType type, Expression left, Expression right)
        {
            return type == CompositionType.And ? Expression.And(left, right) : Expression.Or(left, right);
        }
    }
}