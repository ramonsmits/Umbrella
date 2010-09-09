using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using nVentive.Umbrella.Extensions;

namespace nVentive.Umbrella.Expressions
{
    public class EditableMemberExpression : EditableExpression<MemberExpression>
    {
        public EditableMemberExpression(MemberExpression expression)
            : base(expression, false)
        {
            Member = expression.Member;
            Expression = expression.Expression.Edit();
        }

        public MemberInfo Member { get; set; }

        public IEditableExpression Expression { get; set; }

        public override IEnumerable<IEditableExpression> Nodes
        {
            get { yield return Expression; }
        }

        public override MemberExpression DoToExpression()
        {
            return System.Linq.Expressions.Expression.MakeMemberAccess(Expression.ToExpression(), Member);
        }
    }
}