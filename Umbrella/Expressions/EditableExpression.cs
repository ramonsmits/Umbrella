using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace nVentive.Umbrella.Expressions
{
    public abstract class EditableExpression<T> : IEditableExpression
        where T : Expression
    {
        private readonly bool nodeTypeEditable;
        private readonly T originalExpression;
        private Expression expressionOverride;
        private ExpressionType nodeType;

        // TODO: convert to protected
        public EditableExpression(T expression)
            : this(expression, true)
        {
        }

        // TODO: convert to protected
        public EditableExpression(T expression, bool nodeTypeEditable)
        {
            //TODO Validate expression != null
            originalExpression = expression;
            nodeType = expression.NodeType;
            this.nodeTypeEditable = nodeTypeEditable;
        }

        #region IEditableExpression Members

        public Expression OriginalExpression
        {
            get { return originalExpression; }
        }

        public virtual ExpressionType NodeType
        {
            get { return nodeType; }
            set
            {
                if (!nodeTypeEditable)
                {
                    throw new InvalidOperationException("Cannot change NodeType!");
                }
                nodeType = value;
            }
        }

        public Type ExpressionType
        {
            get { return typeof (T); }
        }

        Expression IEditableExpression.ToExpression()
        {
            return ToExpression();
        }

        public virtual IEnumerable<IEditableExpression> Nodes
        {
            get { return new IEditableExpression[0]; }
        }

        public virtual void Use(Expression expression)
        {
            if (ShouldUse(expression))
            {
                expressionOverride = expression;
            }
        }

        #endregion

        public virtual T ToExpression()
        {
            if (expressionOverride == null)
            {
                return DoToExpression();
            }
            return expressionOverride as T;
        }

        public abstract T DoToExpression();

        protected virtual bool ShouldUse(Expression expression)
        {
            if (expression.NodeType == NodeType &&
                expression is T)
            {
                var castedExpression = expression as T;

                return ShouldUse(castedExpression);
            }
            
            return false;
        }

        protected virtual bool ShouldUse(T expression)
        {
            return true;
        }
    }
}