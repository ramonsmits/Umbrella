using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace nVentive.Umbrella.Expressions
{
    public interface IEditableExpressionExtensions
    {
        EditableLambdaExpression<T> Edit<T>(Expression<T> expression);
        EditableConstantExpression Edit(ConstantExpression expression);
        EditableBinaryExpression Edit(BinaryExpression expression);
        EditableConditionalExpression Edit(ConditionalExpression expression);
        EditableInvocationExpression Edit(InvocationExpression expression);
        EditableLambdaExpression Edit(LambdaExpression expression);
        EditableParameterExpression Edit(ParameterExpression expression);
        EditableListInitExpression Edit(ListInitExpression expression);
        EditableMemberExpression Edit(MemberExpression expression);
        EditableMemberInitExpression Edit(MemberInitExpression expression);
        EditableMethodCallExpression Edit(MethodCallExpression expression);
        EditableNewArrayExpression Edit(NewArrayExpression expression);
        EditableNewExpression Edit(NewExpression expression);
        EditableTypeBinaryExpression Edit(TypeBinaryExpression expression);
        EditableUnaryExpression Edit(UnaryExpression expression);
        IEditableExpression Edit(Expression expression);
        IEnumerable<IEditableExpression> Edit(IEnumerable<Expression> expressions);
        IEnumerable<IEditableExpression> AllNodes(IEditableExpression expression);
        void Use(IEditableExpression editableExpression, Expression expression);
        void Use(IEditableExpression editableExpression, IEnumerable<Expression> expressions);
    }
}
