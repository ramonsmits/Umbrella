using System.Collections.Generic;
using System.Linq.Expressions;
using nVentive.Umbrella.Extensions;

namespace nVentive.Umbrella.Expressions
{
    public class EditableConditionalExpression : EditableExpression<ConditionalExpression>
    {
        public EditableConditionalExpression(ConditionalExpression expression)
            : base(expression)
        {
            Test = expression.Test.Edit();
            IfTrue = expression.IfTrue.Edit();
            IfFalse = expression.IfFalse.Edit();
        }

        public IEditableExpression Test { get; set; }

        public IEditableExpression IfTrue { get; set; }

        public IEditableExpression IfFalse { get; set; }

        public override IEnumerable<IEditableExpression> Nodes
        {
            get
            {
                yield return Test;
                yield return IfTrue;
                yield return IfFalse;
            }
        }

        public override ConditionalExpression DoToExpression()
        {
            return Expression.Condition(Test.ToExpression(), IfTrue.ToExpression(), IfFalse.ToExpression());
        }
    }
}