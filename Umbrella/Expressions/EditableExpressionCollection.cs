using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using nVentive.Umbrella.Extensions;

namespace nVentive.Umbrella.Expressions
{
    public class EditableExpressionCollection<T>
        where T : Expression
    {
        private readonly IList<EditableExpression<T>> items;

        public EditableExpressionCollection(IEnumerable<Expression> items)
        {
            this.items = new List<EditableExpression<T>>(items.Edit().Cast<EditableExpression<T>>());
        }

        // TODO parameter can be type IEnumerable
        public EditableExpressionCollection(IEnumerable<T> items)
            : this(items.Cast<Expression>())
        {
        }

        public IList<EditableExpression<T>> Items
        {
            get { return items; }
        }

        public virtual T[] ToExpression()
        {
            return items.Select(item => item.DoToExpression()).ToArray();
        }
    }
}