using System;

namespace nVentive.Umbrella.Extensions.Calendar
{
	public static class Int64TimeSpanExtensions
	{
		private static double AsD(this long self)
		{
			return self;
		}

		/// <summary>
		/// Returns value as a number of Ticks.
		/// </summary>
		/// <param name="self">The value</param>
		/// <remarks>
		/// This is the singular version.  Typically only used when value is 1
		/// </remarks>
		/// <example>
		/// 1L.Tick().FromNow();
		/// </example>
		public static TimeSpan Tick(this long self)
		{
			return self.Ticks();
		}

		/// <summary>
		/// Returns value as a number of Ticks
		/// </summary>
		/// <param name="self">The value</param>
		/// <example>
		/// 1000L.Ticks().Ago();
		/// </example>
		public static TimeSpan Ticks(this long self)
		{
			return TimeSpan.FromTicks(self);
		}

		/// <summary>
		/// Returns value as a number of milliseconds.
		/// </summary>
		/// <param name="self">The value</param>
		/// <remarks>
		/// This is the singular version.  Typically only used when value is 1
		/// </remarks>
		/// <example>
		/// 1L.Millisecond().FromNow();
		/// </example>
		public static TimeSpan Millisecond(this long self)
		{
			return self.AsD().Millisecond();
		}

		/// <summary>
		/// Returns value as a number of Milliseconds
		/// </summary>
		/// <param name="self">The value</param>
		/// <example>
		/// 1000L.Milliseconds().Ago();
		/// </example>
		public static TimeSpan Milliseconds(this long self)
		{
			return self.AsD().Milliseconds();
		}

		/// <summary>
		/// Returns value as a number of Seconds.
		/// </summary>
		/// <param name="self">The value</param>
		/// <remarks>
		/// This is the singular version.  Typically only used when value is 1
		/// </remarks>
		/// <example>
		/// 1L.Second().FromNow();
		/// </example>
		public static TimeSpan Second(this long self)
		{
			return self.AsD().Second();
		}

		/// <summary>
		/// Returns value as a number of Seconds
		/// </summary>
		/// <param name="self">The value</param>
		/// <example>
		/// 1000L.Seconds().Ago();
		/// </example>
		public static TimeSpan Seconds(this long self)
		{
			return self.AsD().Seconds();
		}

		/// <summary>
		/// Returns value as a number of Minutes.
		/// </summary>
		/// <param name="self">The value</param>
		/// <remarks>
		/// This is the singular version.  Typically only used when value is 1
		/// </remarks>
		/// <example>
		/// 1L.Minute().FromNow();
		/// </example>
		public static TimeSpan Minute(this long self)
		{
			return self.AsD().Minute();
		}

		/// <summary>
		/// Returns value as a number of Minutes
		/// </summary>
		/// <param name="self">The value</param>
		/// <example>
		/// 1000L.Minutes().Ago();
		/// </example>
		public static TimeSpan Minutes(this long self)
		{
			return self.AsD().Minutes();
		}

		/// <summary>
		/// Returns value as a number of Hours.
		/// </summary>
		/// <param name="self">The value</param>
		/// <remarks>
		/// This is the singular version.  Typically only used when value is 1
		/// </remarks>
		/// <example>
		/// 1L.Hour().FromNow();
		/// </example>
		public static TimeSpan Hour(this long self)
		{
			return self.AsD().Hour();
		}

		/// <summary>
		/// Returns value as a number of Hours
		/// </summary>
		/// <param name="self">The value</param>
		/// <example>
		/// 1000L.Hours().Ago();
		/// </example>
		public static TimeSpan Hours(this long self)
		{
			return self.AsD().Hours();
		}

		/// <summary>
		/// Returns value as a number of Days.
		/// </summary>
		/// <param name="self">The value</param>
		/// <remarks>
		/// This is the singular version.  Typically only used when value is 1
		/// </remarks>
		/// <example>
		/// 1L.Day().FromNow();
		/// </example>
		public static TimeSpan Day(this long self)
		{
			return self.AsD().Day();
		}

		/// <summary>
		/// Returns value as a number of Days
		/// </summary>
		/// <param name="self">The value</param>
		/// <example>
		/// 1000L.Days().Ago();
		/// </example>
		public static TimeSpan Days(this long self)
		{
			return self.AsD().Days();
		}

		/// <summary>
		/// Returns value as a number of Weeks.
		/// </summary>
		/// <param name="self">The value</param>
		/// <remarks>
		/// This is the singular version.  Typically only used when value is 1
		/// </remarks>
		/// <example>
		/// 1L.Week().FromNow();
		/// </example>
		public static TimeSpan Week(this long self)
		{
			return self.AsD().Week();
		}

		/// <summary>
		/// Returns value as a number of Weeks
		/// </summary>
		/// <param name="self">The value</param>
		/// <example>
		/// 1000L.Weeks().Ago();
		/// </example>
		public static TimeSpan Weeks(this long self)
		{
			return self.AsD().Weeks();
		}

		/// <summary>
		/// Returns value as a number of Months.
		/// </summary>
		/// <param name="self">The value</param>
		/// <remarks>
		/// This is the singular version.  Typically only used when value is 1
		/// </remarks>
		/// <example>
		/// 1L.Month().FromNow();
		/// </example>
		/// <seealso cref="Months"/>
		public static TimeSpan Month(this long self)
		{
			return self.AsD().Month();
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
		/// 1000L.Months().Ago();
		/// </example>
		public static TimeSpan Months(this long self)
		{
			return self.AsD().Months();
		}

		/// <summary>
		/// Returns value as a number of Years.
		/// </summary>
		/// <param name="self">The value</param>
		/// <remarks>
		/// This is the singular version.  Typically only used when value is 1
		/// </remarks>
		/// <example>
		/// 1L.Year().FromNow();
		/// </example>
		/// <seealso cref="Years"/>
		public static TimeSpan Year(this long self)
		{
			return self.AsD().Year();
		}

		/// <summary>
		/// Returns value as a number of Years
		/// </summary>
		/// <param name="self">The value</param>
		/// <remarks>
		/// This assumes 365 days per year.
		/// </remarks>
		/// <example>
		/// 1000L.Years().Ago();
		/// </example>
		public static TimeSpan Years(this long self)
		{
			return self.AsD().Years();
		}
	}
}
