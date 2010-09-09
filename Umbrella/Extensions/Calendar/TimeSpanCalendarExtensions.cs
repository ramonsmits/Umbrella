using System;

namespace nVentive.Umbrella.Extensions.Calendar
{
	public static class TimeSpanCalendarExtensions
	{
		public static IDateTimeCalendarExtensions Extensions
		{
			get { return ExtensionsProvider.Get<IDateTimeCalendarExtensions, DefaultDateTimeCalendarExtensions>(); }
		}

		/// <summary>
		/// Returns the current DateTime with self added to it
		/// </summary>
		/// <param name="self">The TimeSpan</param>
		public static DateTime FromNow(this TimeSpan self)
		{
			return Extensions.Now.Add(self);
		}

		/// <summary>
		/// Returns the current DateTime with self added to it.
		/// </summary>
		/// <param name="self">The TimeSpan</param>
		/// <param name="kind">The type of DateTime to return.  Defaults to local if DateTimeKind is not
		/// a valid value.</param>
		public static DateTime FromNow(this TimeSpan self, DateTimeKind kind)
		{
			if (kind == DateTimeKind.Utc)
				return Extensions.UtcNow.Add(self);
			return Extensions.Now.Add(self);
		}

		/// <summary>
		/// Returns the current DateTime with self subtracted from it.
		/// </summary>
		/// <param name="self">The TimeSpan</param>
		public static DateTime Ago(this TimeSpan self)
		{
			return Extensions.Now.Subtract(self);
		}

		/// <summary>
		/// Returns the current DateTime with self subtracted from it.
		/// </summary>
		/// <param name="self">The TimeSpan</param>
		/// <param name="kind">The type of DateTime to return.  Defaults to local if DateTimeKind is not
		/// a valid value.</param>
		public static DateTime Ago(this TimeSpan self, DateTimeKind kind)
		{
			if (kind == DateTimeKind.Utc)
				return Extensions.UtcNow.Subtract(self);
			return Extensions.Now.Subtract(self);
		}
	}
}
