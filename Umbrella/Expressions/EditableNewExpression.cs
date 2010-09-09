using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace nVentive.Umbrella.Expressions
{
    public class EditableNewExpression : EditableExpression<NewExpression>
    {
        private readonly EditableExpressionCollection<Expression> arguments;

        public EditableNewExpression(NewExpression expression)
            : base(expression, false)
        {
            arguments = new EditableExpressionCollection<Expression>(expression.Arguments);
            Constructor = expression.Constructor;
        }

        public ConstructorInfo Constructor { get; set; }

        public EditableExpressionCollection<Expression> Arguments
        {
            get { return arguments; }
        }

        public override IEnumerable<IEditableExpression> Nodes
        {
            get { return Arguments.Items.Cast<IEditableExpression>(); }
        }

        public override NewExpression DoToExpression()
        {
            return Expression.New(Constructor, arguments.ToExpression());
        }
    }
}