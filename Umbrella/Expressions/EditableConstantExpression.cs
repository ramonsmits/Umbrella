using System.Linq.Expressions;

namespace nVentive.Umbrella.Expressions
{
    public class EditableConstantExpression : EditableExpression<ConstantExpression>
    {
        public EditableConstantExpression(ConstantExpression expression)
            : base(expression, false)
        {
            Value = expression.Value;
        }

        public object Value { get; set; }

        public override ConstantExpression DoToExpression()
        {
            return Expression.Constant(Value);
        }
    }
}