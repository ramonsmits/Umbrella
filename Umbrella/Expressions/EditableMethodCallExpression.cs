using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using nVentive.Umbrella.Extensions;

namespace nVentive.Umbrella.Expressions
{
    public class EditableMethodCallExpression : EditableExpression<MethodCallExpression>
    {
        private readonly EditableExpressionCollection<Expression> arguments;

        public EditableMethodCallExpression(MethodCallExpression expression)
            : base(expression, false)
        {
            Method = expression.Method;
            Object = expression.Object.Edit();
            arguments = new EditableExpressionCollection<Expression>(expression.Arguments);
        }

        public MethodInfo Method { get; set; }

        public IEditableExpression Object { get; set; }

        public EditableExpressionCollection<Expression> Arguments
        {
            get { return arguments; }
        }

        public override IEnumerable<IEditableExpression> Nodes
        {
            get
            {
                yield return Object;
                foreach (var item in Arguments.Items)
                {
                    yield return item;
                }
            }
        }

        public override MethodCallExpression DoToExpression()
        {
            return Expression.Call(Object.ToExpression(), Method, arguments.ToExpression());
        }
    }
}