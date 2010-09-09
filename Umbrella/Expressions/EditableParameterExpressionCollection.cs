using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using nVentive.Umbrella.Extensions;

namespace nVentive.Umbrella.Expressions
{
    public class EditableParameterExpressionCollection : EditableExpressionCollection<ParameterExpression>
    {
        private readonly IEditableExpression body;
        private IEnumerable<ParameterExpression> parametersOverride;

        public EditableParameterExpressionCollection(IEditableExpression body, IEnumerable<ParameterExpression> items)
            : base(items)
        {
            this.body = body;
        }

        public IEnumerable<EditableParameterExpression> Parameters
        {
            get { return Items.Cast<EditableParameterExpression>(); }
        }

        public void Use(IEnumerable<ParameterExpression> parameters)
        {
            parametersOverride = parameters;
        }

        public override ParameterExpression[] ToExpression()
        {
            var expressions = new List<ParameterExpression>();

            if (parametersOverride == null)
            {
                var bodyParams = body.AllNodes().OfType<EditableParameterExpression>();

                foreach (var param in Parameters)
                {
                    // TODO: Closure problem - Do we want closure?
                    var param1 = param;
                    //TODO Check if more than one param matches?
                    var bodyParam = bodyParams.FirstOrDefault(item => item.Type == param1.Type && item.Name == param1.Name);

                    expressions.Add((bodyParam ?? param).DoToExpression());
                }
            }
            else
            {
                expressions.AddRange(parametersOverride);
            }

            return expressions.ToArray();
        }
    }
}