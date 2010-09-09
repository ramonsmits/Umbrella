using System;

namespace nVentive.Umbrella.Extensions
{
	public static class CurryExtensions
	{
		#region Func currying extenions

		public static Func<TResult> 
			Curry<T, TResult>(this Func<T, TResult> func, T value)
		{
			return () => func(value);
		}

		public static Func<T2, TResult> 
			CurryFirst<T1, T2, TResult>(this Func<T1, T2, TResult> func, T1 first)
		{
			return (T2 last) => func(first, last);
		}

		public static Func<T1, TResult> 
			CurryLast<T1, T2, TResult>(this Func<T1, T2, TResult> func, T2 last)
		{
			return (T1 first) => func(first, last);
		}

		public static Func<T2, T3, TResult>
			CurryFirst<T1, T2, T3, TResult>(this Func<T1, T2, T3, TResult> func, T1 first)
		{
			return (T2 second, T3 last) => func(first, second, last);
		}

		public static Func<T1, T2, TResult> 
			CurryLast<T1, T2, T3, TResult>(this Func<T1, T2, T3, TResult> func, T3 last)
		{
			return (T1 first, T2 second) => func(first, second, last);
		}

		public static Func<T2, T3, T4, TResult>
			CurryFirst<T1, T2, T3, T4, TResult>(this Func<T1, T2, T3, T4, TResult> func, T1 first)
		{
			return (T2 second, T3 third, T4 last) => func(first, second, third, last);
		}

		public static Func<T1, T2, T3, TResult> 
			CurryLast<T1, T2, T3, T4, TResult>(this Func<T1, T2, T3, T4, TResult> func, T4 last)
		{
			return (T1 first, T2 second, T3 third) => func(first, second, third, last);
		}

		#endregion

		#region Action currying extensions

		public static Action
			Curry<T>(this Action<T> action, T value)
		{
			return () => action(value);
		}

		public static Action<T2>
			CurryFirst<T1, T2>(this Action<T1, T2> action, T1 first)
		{
			return (T2 last) => action(first, last);
		}

		public static Action<T1>
			CurryLast<T1, T2>(this Action<T1, T2> action, T2 last)
		{
			return (T1 first) => action(first, last);
		}

		public static Action<T2, T3>
			CurryFirst<T1, T2, T3>(this Action<T1, T2, T3> action, T1 first)
		{
			return (T2 second, T3 last) => action(first, second, last);
		}

		public static Action<T1, T2>
			CurryLast<T1, T2, T3>(this Action<T1, T2, T3> action, T3 last)
		{
			return (T1 first, T2 second) => action(first, second, last);
		}

		public static Action<T2, T3, T4>
			CurryFirst<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> action, T1 first)
		{
			return (T2 second, T3 third, T4 last) => action(first, second, third, last);
		}

		public static Action<T1, T2, T3>
			CurryLast<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> action, T4 last)
		{
			return (T1 first, T2 second, T3 third) => action(first, second, third, last);
		}

		#endregion 
	}
}
