using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using nVentive.Umbrella.Extensions;

namespace nVentive.Umbrella.Expressions
{
    public class EditableInvocationExpression : EditableExpression<InvocationExpression>
    {
        private readonly EditableExpressionCollection<Expression> arguments;

        public EditableInvocationExpression(InvocationExpression expression)
            : base(expression, false)
        {
            Expression = expression.Expression.Edit();
            arguments = new EditableExpressionCollection<Expression>(expression.Arguments);
        }

        public EditableExpressionCollection<Expression> Arguments
        {
            get { return arguments; }
        }

        public IEditableExpression Expression { get; set; }

        public override IEnumerable<IEditableExpression> Nodes
        {
            get { return Arguments.Items.Cast<IEditableExpression>(); }
        }

        public override InvocationExpression DoToExpression()
        {
            return System.Linq.Expressions.Expression.Invoke(Expression.ToExpression(), Arguments.ToExpression());
        }
    }
}