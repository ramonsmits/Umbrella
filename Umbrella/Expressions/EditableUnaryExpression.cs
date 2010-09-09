using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using nVentive.Umbrella.Extensions;

namespace nVentive.Umbrella.Expressions
{
    public class EditableUnaryExpression : EditableExpression<UnaryExpression>
    {
        public EditableUnaryExpression(UnaryExpression expression)
            : base(expression)
        {
            Type = expression.Type;
            Operand = expression.Operand.Edit();
        }

        public Type Type { get; set; }

        public IEditableExpression Operand { get; set; }

        public override IEnumerable<IEditableExpression> Nodes
        {
            get { yield return Operand; }
        }

        public override UnaryExpression DoToExpression()
        {
            return Expression.MakeUnary(NodeType, Operand.ToExpression(), Type);
        }
    }
}