using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

using nVentive.Umbrella.Extensions;

namespace nVentive.Umbrella.Expressions
{
    public class DefaultEditableExpressionExtensions : IEditableExpressionExtensions
    {
        public virtual EditableLambdaExpression<T> Edit<T>(Expression<T> expression)
        {
        }

        public virtual EditableConstantExpression Edit(ConstantExpression expression)
        {
        }

        public virtual EditableBinaryExpression Edit(BinaryExpression expression)
        {
        }

        public virtual EditableConditionalExpression Edit(ConditionalExpression expression)
        {
        }

        public virtual EditableInvocationExpression Edit(InvocationExpression expression)
        {
        }

        public virtual EditableLambdaExpression Edit(LambdaExpression expression)
        {
        }

        public virtual EditableParameterExpression Edit(ParameterExpression expression)
        {
        }

        public virtual EditableListInitExpression Edit(ListInitExpression expression)
        {
        }

        public virtual EditableMemberExpression Edit(MemberExpression expression)
        {
        }

        public virtual EditableMemberInitExpression Edit(MemberInitExpression expression)
        {
        }

        public virtual EditableMethodCallExpression Edit(MethodCallExpression expression)
        {
        }

        public virtual EditableNewArrayExpression Edit(NewArrayExpression expression)
        {
        }

        public virtual EditableNewExpression Edit(NewExpression expression)
        {
        }

        public virtual EditableTypeBinaryExpression Edit(TypeBinaryExpression expression)
        {
        }

        public virtual EditableUnaryExpression Edit(UnaryExpression expression)
        {
        }

        public virtual IEditableExpression Edit(Expression ex)
        {
        }

        public virtual IEnumerable<IEditableExpression> Edit(IEnumerable<Expression> expressions)
        {
        }

        public virtual IEnumerable<IEditableExpression> AllNodes(IEditableExpression expression)
        {
        }

        public virtual void Use(IEditableExpression editableExpression, Expression expression)
        {
        }

        public virtual void Use(IEditableExpression editableExpression, IEnumerable<Expression> expressions)
        {
        }
    }
}
