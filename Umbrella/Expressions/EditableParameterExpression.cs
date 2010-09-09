using System;
using System.Linq.Expressions;

namespace nVentive.Umbrella.Expressions
{
    public class EditableParameterExpression : EditableExpression<ParameterExpression>
    {
        public EditableParameterExpression(ParameterExpression expression)
            : base(expression, false)
        {
            Type = expression.Type;
            Name = expression.Name;
        }

        public Type Type { get; set; }

        public string Name { get; set; }

        public override ParameterExpression DoToExpression()
        {
            return Expression.Parameter(Type, Name);
        }

        protected override bool ShouldUse(ParameterExpression expression)
        {
            return expression.Type == Type /* &&
                    expression.Name == Name*/;
                //TODO Support Name, Index strategies to compare parameters (Require Parent Collection for index?)
        }
    }
}