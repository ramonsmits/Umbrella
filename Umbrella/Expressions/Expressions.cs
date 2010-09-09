using System;
using System.Linq.Expressions;

namespace nVentive.Umbrella.Expressions
{
    public class Expressions<T>
    {
        public static readonly Expression<Func<T, bool>> False = item => false;
        public static readonly Expression<Func<T, bool>> True = item => true;
    }
}