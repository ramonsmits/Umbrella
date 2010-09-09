using System.Collections.Generic;
using System.Linq.Expressions;
using nVentive.Umbrella.Extensions;

namespace nVentive.Umbrella.Expressions
{
    public class EditableBinaryExpression : EditableExpression<BinaryExpression>
    {
        public EditableBinaryExpression(BinaryExpression expression)
            : base(expression)
        {
            Left = expression.Left.Edit();
            Right = expression.Right.Edit();
        }

        public IEditableExpression Left { get; set; }

        public IEditableExpression Right { get; set; }

        public override IEnumerable<IEditableExpression> Nodes
        {
            get
            {
                yield return Left;
                yield return Right;
            }
        }

        public override BinaryExpression DoToExpression()
        {
            return Expression.MakeBinary(NodeType, Left.ToExpression(), Right.ToExpression());
        }
    }
}