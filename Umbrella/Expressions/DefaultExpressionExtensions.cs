using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Reflection;

using nVentive.Umbrella.Extensions;
using nVentive.Umbrella.Validation;

namespace nVentive.Umbrella.Expressions
{
    public class DefaultExpressionExtensions : IExpressionExtensions
    {
        #region IExpressionExtensions Members

        public virtual Expression<Func<T, bool>> And<T>(Expression<Func<T, bool>> left, params Expression<Func<T, bool>>[] items)
        {
            Expression<Func<T, bool>> result = left;

            items.ForEach(item => result = Binary(CompositionType.And, result, item));
            
            return result;
        }

        public virtual Expression<Func<T, bool>> Or<T>(Expression<Func<T, bool>> left, params Expression<Func<T, bool>>[] items)
        {
            Expression<Func<T, bool>> result = left;

            items.ForEach(item => result = Binary(CompositionType.Or, result, item));

            return result;
        }

        public virtual Expression<Func<T, bool>> Not<T>(Expression<Func<T, bool>> expression)
        {
            return Expression.Lambda<Func<T, bool>>(Expression.Not(expression.Body), expression.Parameters);
        }

        #endregion

        protected virtual Expression<T> Binary<T>(CompositionType type, Expression<T> left, Expression<T> right)
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

            Expression newBody = Binary(type, left.Body, right.Body);

            return Expression.Lambda<T>(newBody, left.Parameters);
        }

        protected virtual Expression<T> ReplaceParameters<T>(Expression<T> source, Expression<T> target)
        {
            EditableLambdaExpression<T> editableTarget = target.Edit();

            editableTarget.Use(source.Parameters.Cast<Expression>());

            target = editableTarget.ToExpression();

            return target;
        }

        protected virtual Expression Binary(CompositionType type, Expression left, Expression right)
        {
            if (type == CompositionType.And)
            {
                return Expression.And(left, right);
            }
            else
            {
                return Expression.Or(left, right);
            }
        }
    }
}
