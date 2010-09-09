using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace nVentive.Umbrella.Expressions
{
    public class EditableNewArrayExpression : EditableExpression<NewArrayExpression>
    {
        private readonly EditableExpressionCollection<Expression> expressions;

        public EditableNewArrayExpression(NewArrayExpression expression)
            : base(expression)
        {
            Type = expression.Type;
            expressions = new EditableExpressionCollection<Expression>(expression.Expressions);
        }

        public override ExpressionType NodeType
        {
            get { return base.NodeType; }
            set
            {
                switch (value)
                {
                    case System.Linq.Expressions.ExpressionType.NewArrayInit:
                    case System.Linq.Expressions.ExpressionType.NewArrayBounds:
                        base.NodeType = value;
                        break;

                    default:
                        throw new InvalidOperationException(
                            "NodeType for NewArrayExpression must be ExpressionType.NewArrayInit or ExpressionType.NewArrayBounds");
                }
            }
        }

        public Type Type { get; set; }

        public EditableExpressionCollection<Expression> Expressions
        {
            get { return expressions; }
        }

        public override IEnumerable<IEditableExpression> Nodes
        {
            get { return Expressions.Items.Cast<IEditableExpression>(); }
        }

        public override NewArrayExpression DoToExpression()
        {
            switch (NodeType)
            {
                case System.Linq.Expressions.ExpressionType.NewArrayInit:
                    return Expression.NewArrayInit(Type, expressions.ToExpression());

                case System.Linq.Expressions.ExpressionType.NewArrayBounds:
                    return Expression.NewArrayBounds(Type, expressions.ToExpression());

                default:
                    throw new InvalidOperationException(
                        "NodeType for NewArrayExpression must be ExpressionType.NewArrayInit or ExpressionType.NewArrayBounds");
            }
        }
    }
}