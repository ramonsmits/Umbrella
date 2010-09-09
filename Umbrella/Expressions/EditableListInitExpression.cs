using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using nVentive.Umbrella.Extensions;

namespace nVentive.Umbrella.Expressions
{
    public class EditableListInitExpression : EditableExpression<ListInitExpression>
    {
        private readonly List<EditableElementInit> initializers;

        public EditableListInitExpression(ListInitExpression expression)
            : base(expression, false)
        {
            initializers = new List<EditableElementInit>(expression.Initializers.Select(item => new EditableElementInit(item)));
            NewExpression = expression.NewExpression.Edit();
        }

        public EditableNewExpression NewExpression { get; set; }

        public IList<EditableElementInit> Initializers
        {
            get { return initializers; }
        }

        public override IEnumerable<IEditableExpression> Nodes
        {
            get
            {
                yield return NewExpression;
                foreach (var init in Initializers.SelectMany(item => item.Arguments.Items).Cast<IEditableExpression>())
                {
                    yield return init;
                }
            }
        }

        public override ListInitExpression DoToExpression()
        {
            return Expression.ListInit(NewExpression.DoToExpression(),
                                       initializers.Select(item => item.ToElementInit()).ToArray());
        }
    }
}