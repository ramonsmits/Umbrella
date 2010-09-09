using System;

namespace nVentive.Umbrella.Extensions.Calendar
{
	public static class SingleTimeSpanExtensions
	{
		private static double AsD(this float self)
		{
			return self;
		}

		public static long AsL(this float self)
		{
			return (long)self;
		}

		/// <summary>
		/// Returns value as a number of Ticks.
		/// </summary>
		/// <param name="self">The value</param>
		/// <remarks>
		/// This is the singular version.  Typically only used when value is 1
		/// </remarks>
		/// <example>
		/// 1F.Tick().FromNow();
		/// </example>
		public static TimeSpan Tick(this float self)
		{
			return self.AsL().Tick();
		}

		/// <summary>
		/// Returns value as a number of Ticks
		/// </summary>
		/// <param name="self">The value</param>
		/// <example>
		/// 1000F.Ticks().Ago();
		/// </example>
		public static TimeSpan Ticks(this float self)
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
		/// 1F.Millisecond().FromNow();
		/// </example>
		public static TimeSpan Millisecond(this float self)
		{
			return self.AsD().Millisecond();
		}

		/// <summary>
		/// Returns value as a number of Milliseconds
		/// </summary>
		/// <param name="self">The value</param>
		/// <example>
		/// 1000F.Milliseconds().Ago();
		/// </example>
		public static TimeSpan Milliseconds(this float self)
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
		/// 1F.Second().FromNow();
		/// </example>
		public static TimeSpan Second(this float self)
		{
			return self.AsD().Second();
		}

		/// <summary>
		/// Returns value as a number of Seconds
		/// </summary>
		/// <param name="self">The value</param>
		/// <example>
		/// 1000F.Seconds().Ago();
		/// </example>
		public static TimeSpan Seconds(this float self)
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
		/// 1F.Minute().FromNow();
		/// </example>
		public static TimeSpan Minute(this float self)
		{
			return self.AsD().Minute();
		}

		/// <summary>
		/// Returns value as a number of Minutes
		/// </summary>
		/// <param name="self">The value</param>
		/// <example>
		/// 1000F.Minutes().Ago();
		/// </example>
		public static TimeSpan Minutes(this float self)
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
		/// 1F.Hour().FromNow();
		/// </example>
		public static TimeSpan Hour(this float self)
		{
			return self.AsD().Hour();
		}

		/// <summary>
		/// Returns value as a number of Hours
		/// </summary>
		/// <param name="self">The value</param>
		/// <example>
		/// 1000F.Hours().Ago();
		/// </example>
		public static TimeSpan Hours(this float self)
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
		/// 1F.Day().FromNow();
		/// </example>
		public static TimeSpan Day(this float self)
		{
			return self.AsD().Day();
		}

		/// <summary>
		/// Returns value as a number of Days
		/// </summary>
		/// <param name="self">The value</param>
		/// <example>
		/// 1000F.Days().Ago();
		/// </example>
		public static TimeSpan Days(this float self)
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
		/// 1F.Week().FromNow();
		/// </example>
		public static TimeSpan Week(this float self)
		{
			return self.AsD().Week();
		}

		/// <summary>
		/// Returns value as a number of Weeks
		/// </summary>
		/// <param name="self">The value</param>
		/// <example>
		/// 1000F.Weeks().Ago();
		/// </example>
		public static TimeSpan Weeks(this float self)
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
		/// 1F.Month().FromNow();
		/// </example>
		/// <seealso cref="Months"/>
		public static TimeSpan Month(this float self)
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
		/// 1000F.Months().Ago();
		/// </example>
		public static TimeSpan Months(this float self)
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
		/// 1F.Year().FromNow();
		/// </example>
		/// <seealso cref="Years"/>
		public static TimeSpan Year(this float self)
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
		/// 1000F.Years().Ago();
		/// </example>
		public static TimeSpan Years(this float self)
		{
			return self.AsD().Years();
		}
	}
}
