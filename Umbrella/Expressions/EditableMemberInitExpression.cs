using System.Collections.Generic;
using System.Linq.Expressions;
using nVentive.Umbrella.Extensions;

namespace nVentive.Umbrella.Expressions
{
    public class EditableMemberInitExpression : EditableExpression<MemberInitExpression>
    {
        private readonly List<MemberBinding> bindings;

        public EditableMemberInitExpression(MemberInitExpression expression)
            : base(expression, false)
        {
            NewExpression = expression.NewExpression.Edit();
            bindings = new List<MemberBinding>(expression.Bindings);
        }

        public EditableNewExpression NewExpression { get; set; }

        public IList<MemberBinding> Bindings
        {
            get { return bindings; }
        }

        public override IEnumerable<IEditableExpression> Nodes
        {
            get { yield return NewExpression; }
        }

        public override MemberInitExpression DoToExpression()
        {
            return Expression.MemberInit(NewExpression.DoToExpression(), Bindings);
        }
    }
}