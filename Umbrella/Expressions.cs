//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Linq.Expressions;
//using System.Reflection;

//namespace Nventive.Framework
//{
//    public static class ExpressionsExtensions
//    {
////public static Expression<Func<T, bool>> Get<T> () { return null; }

////        public static Expression<Func<T, bool>> Get<T> (this Expression<Func<T, bool>> predicate)
////        {
////            return predicate;
////        }

//        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> left, Expression<Func<T, bool>> right)
//        {
//            if (left == null) return right;
//            Replace(right, right.Parameters[0], left.Parameters[0]);
//            return Expression.Lambda<Func<T, bool>>(Expression.Or(left.Body, right.Body), left.Parameters);
//        }

////         public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> exp1, Expression<Func<T, bool>> exp2)
////        {
////            ParameterExpression p = Expression.Parameter(typeof(T), "p");
////            return Expression.Lambda<Func<T, bool>>(Expression.And(Expression.Invoke(exp1, p), Expression.Invoke(exp2, p)), p);
////        }

////        //public static Expression<Func<T, bool>> And<T> (this Expression<Func<T, bool>> expr, Expression<Func<T, bool>> and)
////        //{
////        //    if (expr == null) return and;
////        //    Replace (and, and.Parameters[0], expr.Parameters[0]);
////        //    return Expression.Lambda<Func<T, bool>> (Expression.And (expr.Body, and.Body), expr.Parameters);
////        //}

//        static void Replace(object instance, object old, object replacement)
//        {
//            for (Type t = instance.GetType(); t != null; t = t.BaseType)
//                foreach (FieldInfo fi in t.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
//                {
//                    object val = fi.GetValue(instance);
//                    if (val != null && val.GetType().Assembly == typeof(Expression).Assembly)
//                        if (object.ReferenceEquals(val, old))
//                            fi.SetValue(instance, replacement);
//                        else
//                            Replace(val, old, replacement);
//                }
//        }

//        public static Expression<Func<T, bool>> True<T>() { return f => true; }
//        public static Expression<Func<T, bool>> False<T>() { return f => false; }

//        //public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> expr1,
//        //                                                    Expression<Func<T, bool>> expr2)
//        //{
//        //    var invokedExpr = Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>());
//        //    return Expression.Lambda<Func<T, bool>>
//        //          (Expression.Or(expr1.Body, invokedExpr), expr1.Parameters);
//        //}

//        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expr1,
//                                                             Expression<Func<T, bool>> expr2)
//        {
//            var invokedExpr = Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>());
//            return Expression.Lambda<Func<T, bool>>
//                  (Expression.And(expr1.Body, invokedExpr), expr1.Parameters);
//        }

//        //public static Expression<Func<T, bool>> AndEx<T>(this Expression<Func<T, bool>> expr1,
//        //                                                     Expression<Func<T, bool>> expr2)
//        //{
//        //    return x => expr1(x) && expr2(x);
//        //}
//    }
//}
