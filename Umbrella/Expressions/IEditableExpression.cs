using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace nVentive.Umbrella.Expressions
{
    public interface IEditableExpression
    {
        Expression OriginalExpression { get; }
        ExpressionType NodeType { get; set; }
        Type ExpressionType { get; }
        IEnumerable<IEditableExpression> Nodes { get; }
        Expression ToExpression();
        void Use(Expression expression);
    }
}