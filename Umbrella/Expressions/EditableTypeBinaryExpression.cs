using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using nVentive.Umbrella.Extensions;

namespace nVentive.Umbrella.Expressions
{
    public class EditableTypeBinaryExpression : EditableExpression<TypeBinaryExpression>
    {
        public EditableTypeBinaryExpression(TypeBinaryExpression expression)
            : base(expression, false)
        {
            TypeOperand = expression.TypeOperand;
            Expression = expression.Expression.Edit();
        }

        public Type TypeOperand { get; set; }

        public IEditableExpression Expression { get; set; }

        public override IEnumerable<IEditableExpression> Nodes
        {
            get { yield return Expression; }
        }

        public override TypeBinaryExpression DoToExpression()
        {
            return System.Linq.Expressions.Expression.TypeIs(Expression.ToExpression(), TypeOperand);
        }
    }
}