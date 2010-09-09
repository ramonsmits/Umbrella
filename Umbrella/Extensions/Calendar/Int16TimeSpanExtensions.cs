using System;

namespace nVentive.Umbrella.Extensions.Calendar
{
	public static class Int16TimeSpanExtensions
	{
		private static double AsD(this short self)
		{
			return self;
		}

		private static long AsL(this short self)
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
		/// ((short)1).Tick().FromNow();
		/// </example>
		public static TimeSpan Tick(this short self)
		{
			return self.AsL().Tick();
		}

		/// <summary>
		/// Returns value as a number of Ticks
		/// </summary>
		/// <param name="self">The value</param>
		/// <example>
		/// ((short)100).Ticks().Ago();
		/// </example>
		public static TimeSpan Ticks(this short self)
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
		/// ((short)1).Millisecond().FromNow();
		/// </example>
		public static TimeSpan Millisecond(this short self)
		{
			return self.AsD().Millisecond();
		}

		/// <summary>
		/// Returns value as a number of Milliseconds
		/// </summary>
		/// <param name="self">The value</param>
		/// <example>
		/// ((short)100).Milliseconds().Ago();
		/// </example>
		public static TimeSpan Milliseconds(this short self)
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
		/// ((short)1).Second().FromNow();
		/// </example>
		public static TimeSpan Second(this short self)
		{
			return self.AsD().Second();
		}

		/// <summary>
		/// Returns value as a number of Seconds
		/// </summary>
		/// <param name="self">The value</param>
		/// <example>
		/// ((short)100).Seconds().Ago();
		/// </example>
		public static TimeSpan Seconds(this short self)
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
		/// ((short)1).Minute().FromNow();
		/// </example>
		public static TimeSpan Minute(this short self)
		{
			return self.AsD().Minute();
		}

		/// <summary>
		/// Returns value as a number of Minutes
		/// </summary>
		/// <param name="self">The value</param>
		/// <example>
		/// ((short)100).Minutes().Ago();
		/// </example>
		public static TimeSpan Minutes(this short self)
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
		/// ((short)1).Hour().FromNow();
		/// </example>
		public static TimeSpan Hour(this short self)
		{
			return self.AsD().Hour();
		}

		/// <summary>
		/// Returns value as a number of Hours
		/// </summary>
		/// <param name="self">The value</param>
		/// <example>
		/// ((short)100).Hours().Ago();
		/// </example>
		public static TimeSpan Hours(this short self)
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
		/// ((short)1).Day().FromNow();
		/// </example>
		public static TimeSpan Day(this short self)
		{
			return self.AsD().Day();
		}

		/// <summary>
		/// Returns value as a number of Days
		/// </summary>
		/// <param name="self">The value</param>
		/// <example>
		/// ((short)100).Days().Ago();
		/// </example>
		public static TimeSpan Days(this short self)
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
		/// ((short)1).Week().FromNow();
		/// </example>
		public static TimeSpan Week(this short self)
		{
			return self.AsD().Week();
		}

		/// <summary>
		/// Returns value as a number of Weeks
		/// </summary>
		/// <param name="self">The value</param>
		/// <example>
		/// ((short)100).Weeks().Ago();
		/// </example>
		public static TimeSpan Weeks(this short self)
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
		/// ((short)1).Month().FromNow();
		/// </example>
		/// <seealso cref="Months"/>
		public static TimeSpan Month(this short self)
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
		/// ((short)100).Months().Ago();
		/// </example>
		public static TimeSpan Months(this short self)
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
		/// ((short)1).Year().FromNow();
		/// </example>
		/// <seealso cref="Years"/>
		public static TimeSpan Year(this short self)
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
		/// ((short)100).Years().Ago();
		/// </example>
		public static TimeSpan Years(this short self)
		{
			return self.AsD().Years();
		}
	}
}
