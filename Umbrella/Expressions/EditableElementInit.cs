using System.Linq.Expressions;
using System.Reflection;

namespace nVentive.Umbrella.Expressions
{
    public class EditableElementInit
    {
        private readonly EditableExpressionCollection<Expression> arguments;

        public EditableElementInit(ElementInit elementInit)
        {
            AddMethod = elementInit.AddMethod;
            arguments = new EditableExpressionCollection<Expression>(elementInit.Arguments);
        }

        public MethodInfo AddMethod { get; set; }

        public EditableExpressionCollection<Expression> Arguments
        {
            get { return arguments; }
        }

        public ElementInit ToElementInit()
        {
            return Expression.ElementInit(AddMethod, Arguments.ToExpression());
        }
    }
}