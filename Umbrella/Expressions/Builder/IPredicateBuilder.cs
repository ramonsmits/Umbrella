using System;
using System.Linq.Expressions;

namespace nVentive.Umbrella.Expressions.Builder
{
    //TODO
    public interface IPredicateBuilder<T>
    {
        Expression<Func<T, bool>> ToExpression();
    }
}