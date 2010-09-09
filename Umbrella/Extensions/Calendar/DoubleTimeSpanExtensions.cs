using System;

namespace nVentive.Umbrella.Extensions.Calendar
{
	public static class DoubleTimeSpanExtensions
	{
		private static long AsL(this double self)
		{
			return checked((long)self);
		}

		/// <summary>
		/// Returns value as a number of Ticks.
		/// </summary>
		/// <param name="self">The value</param>
		/// <remarks>
		/// This is the singular version.  Typically only used when value is 1
		/// </remarks>
		/// <example>
		/// 1D.Tick().FromNow();
		/// </example>
		public static TimeSpan Tick(this double self)
		{
			return self.AsL().Tick();
		}

		/// <summary>
		/// Returns value as a number of Ticks
		/// </summary>
		/// <param name="self">The value</param>
		/// <example>
		/// 1000D.Ticks().Ago();
		/// </example>
		public static TimeSpan Ticks(this double self)
		{
			return self.AsL().Ticks();
		}

		/// <summary>
		/// Returns value as a number of milliseconds.
		/// </summary>
		/// <param name="self">The value</param>
		/// <remarks>
		/// This is the singular version.  Typically only used when value is 1
		/// </remarks>
		/// <example>
		/// 1D.Millisecond().FromNow();
		/// </example>
		public static TimeSpan Millisecond(this double self)
		{
			return self.Milliseconds();
		}

		/// <summary>
		/// Returns value as a number of Milliseconds
		/// </summary>
		/// <param name="self">The value</param>
		/// <example>
		/// 1000D.Milliseconds().Ago();
		/// </example>
		public static TimeSpan Milliseconds(this double self)
		{
			return TimeSpan.FromMilliseconds(self);
		}

		/// <summary>
		/// Returns value as a number of Seconds.
		/// </summary>
		/// <param name="self">The value</param>
		/// <remarks>
		/// This is the singular version.  Typically only used when value is 1
		/// </remarks>
		/// <example>
		/// 1D.Second().FromNow();
		/// </example>
		public static TimeSpan Second(this double self)
		{
			return self.Seconds();
		}

		/// <summary>
		/// Returns value as a number of Seconds
		/// </summary>
		/// <param name="self">The value</param>
		/// <example>
		/// 1000D.Seconds().Ago();
		/// </example>
		public static TimeSpan Seconds(this double self)
		{
			return TimeSpan.FromSeconds(self);
		}

		/// <summary>
		/// Returns value as a number of Minutes.
		/// </summary>
		/// <param name="self">The value</param>
		/// <remarks>
		/// This is the singular version.  Typically only used when value is 1
		/// </remarks>
		/// <example>
		/// 1D.Minute().FromNow();
		/// </example>
		public static TimeSpan Minute(this double self)
		{
			return self.Minutes();
		}

		/// <summary>
		/// Returns value as a number of Minutes
		/// </summary>
		/// <param name="self">The value</param>
		/// <example>
		/// 1000D.Minutes().Ago();
		/// </example>
		public static TimeSpan Minutes(this double self)
		{
			return TimeSpan.FromMinutes(self);
		}

		/// <summary>
		/// Returns value as a number of Hours.
		/// </summary>
		/// <param name="self">The value</param>
		/// <remarks>
		/// This is the singular version.  Typically only used when value is 1
		/// </remarks>
		/// <example>
		/// 1D.Hour().FromNow();
		/// </example>
		public static TimeSpan Hour(this double self)
		{
			return self.Hours();
		}

		/// <summary>
		/// Returns value as a number of Hours
		/// </summary>
		/// <param name="self">The value</param>
		/// <example>
		/// 1000D.Hours().Ago();
		/// </example>
		public static TimeSpan Hours(this double self)
		{
			return TimeSpan.FromHours(self);
		}

		/// <summary>
		/// Returns value as a number of Days.
		/// </summary>
		/// <param name="self">The value</param>
		/// <remarks>
		/// This is the singular version.  Typically only used when value is 1
		/// </remarks>
		/// <example>
		/// 1D.Day().FromNow();
		/// </example>
		public static TimeSpan Day(this double self)
		{
			return self.Days();
		}

		/// <summary>
		/// Returns value as a number of Days
		/// </summary>
		/// <param name="self">The value</param>
		/// <example>
		/// 1000D.Days().Ago();
		/// </example>
		public static TimeSpan Days(this double self)
		{
			return TimeSpan.FromDays(self);
		}

		/// <summary>
		/// Returns value as a number of Weeks.
		/// </summary>
		/// <param name="self">The value</param>
		/// <remarks>
		/// This is the singular version.  Typically only used when value is 1
		/// </remarks>
		/// <example>
		/// 1D.Week().FromNow();
		/// </example>
		public static TimeSpan Week(this double self)
		{
			return self.Weeks();
		}

		/// <summary>
		/// Returns value as a number of Weeks
		/// </summary>
		/// <param name="self">The value</param>
		/// <example>
		/// 1000D.Weeks().Ago();
		/// </example>
		public static TimeSpan Weeks(this double self)
		{
			return (self * 7D).Days();
		}

		/// <summary>
		/// Returns value as a number of Months.
		/// </summary>
		/// <param name="self">The value</param>
		/// <remarks>
		/// This is the singular version.  Typically only used when value is 1
		/// </remarks>
		/// <example>
		/// 1D.Month().FromNow();
		/// </example>
		/// <seealso cref="Months"/>
		public static TimeSpan Month(this double self)
		{
			return self.Months();
		}

		/// <summary>
		/// Returns value as a number of Months
		/// </summary>
		/// <param name="self">The value</param>
		/// <remarks>
		/// This assumes 30 days per month.  Because of this, it is possible to skip over months
		/// even with small values.
		/// </remarks>
		/// <example>
		/// 1000D.Months().Ago();
		/// </example>
		public static TimeSpan Months(this double self)
		{
			return (self * 30D).Days();
		}

		/// <summary>
		/// Returns value as a number of Years.
		/// </summary>
		/// <param name="self">The value</param>
		/// <remarks>
		/// This is the singular version.  Typically only used when value is 1
		/// </remarks>
		/// <example>
		/// 1D.Year().FromNow();
		/// </example>
		/// <seealso cref="Years"/>
		public static TimeSpan Year(this double self)
		{
			return self.Years();
		}

		/// <summary>
		/// Returns value as a number of Years
		/// </summary>
		/// <param name="self">The value</param>
		/// <remarks>
		/// This assumes 365 days per year.
		/// </remarks>
		/// <example>
		/// 1000D.Years().Ago();
		/// </example>
		public static TimeSpan Years(this double self)
		{
			return (self * 365D).Days();
		}
	}
}
