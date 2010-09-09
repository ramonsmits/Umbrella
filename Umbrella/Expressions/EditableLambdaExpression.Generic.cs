using System.Collections.Generic;
using System.Linq.Expressions;
using nVentive.Umbrella.Extensions;

namespace nVentive.Umbrella.Expressions
{
    public class EditableLambdaExpression<T> : EditableExpression<Expression<T>>
    {
        private readonly EditableParameterExpressionCollection parameters;

        public EditableLambdaExpression(Expression<T> expression)
            : base(expression, false)
        {
            Body = expression.Body.Edit();
            parameters = new EditableParameterExpressionCollection(Body, expression.Parameters);
        }

        public IEditableExpression Body { get; set; }

        public EditableParameterExpressionCollection Parameters
        {
            get { return parameters; }
        }

        public override IEnumerable<IEditableExpression> Nodes
        {
            get
            {
                yield return Body;
                foreach (var item in Parameters.Items)
                {
                    yield return item;
                }
            }
        }

        public override Expression<T> DoToExpression()
        {
            return Expression.Lambda<T>(Body.ToExpression(), Parameters.ToExpression());
        }
    }
}