using System;

namespace nVentive.Umbrella.Extensions.Calendar
{
	public static class ByteTimeSpanExtensions
	{
		private static double AsD(this byte self)
		{
			return ((double)self);
		}

		private static long AsL(this byte self)
		{
			return ((long)self);
		}

		/// <summary>
		/// Returns value as a number of Ticks.
		/// </summary>
		/// <param name="self">The value</param>
		/// <remarks>
		/// This is the singular version.  Typically only used when value is 1
		/// </remarks>
		/// <example>
		/// ((byte)1).Tick().FromNow();
		/// </example>
		public static TimeSpan Tick(this byte self)
		{
			return self.AsL().Tick();
		}

		/// <summary>
		/// Returns value as a number of Ticks
		/// </summary>
		/// <param name="self">The value</param>
		/// <example>
		/// ((byte)10).Ticks().Ago();
		/// </example>
		public static TimeSpan Ticks(this byte self)
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
		/// ((byte)1).Millisecond().FromNow();
		/// </example>
		public static TimeSpan Millisecond(this byte self)
		{
			return self.AsD().Millisecond();
		}

		/// <summary>
		/// Returns value as a number of Milliseconds
		/// </summary>
		/// <param name="self">The value</param>
		/// <example>
		/// ((byte)10).Milliseconds().Ago();
		/// </example>
		public static TimeSpan Milliseconds(this byte self)
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
		/// ((byte)1).Second().FromNow();
		/// </example>
		public static TimeSpan Second(this byte self)
		{
			return self.AsD().Second();
		}

		/// <summary>
		/// Returns value as a number of Seconds
		/// </summary>
		/// <param name="self">The value</param>
		/// <example>
		/// ((byte)10).Seconds().Ago();
		/// </example>
		public static TimeSpan Seconds(this byte self)
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
		/// ((byte)1).Minute().FromNow();
		/// </example>
		public static TimeSpan Minute(this byte self)
		{
			return self.AsD().Minute();
		}

		/// <summary>
		/// Returns value as a number of Minutes
		/// </summary>
		/// <param name="self">The value</param>
		/// <example>
		/// ((byte)10).Minutes().Ago();
		/// </example>
		public static TimeSpan Minutes(this byte self)
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
		/// ((byte)1).Hour().FromNow();
		/// </example>
		public static TimeSpan Hour(this byte self)
		{
			return self.AsD().Hour();
		}

		/// <summary>
		/// Returns value as a number of Hours
		/// </summary>
		/// <param name="self">The value</param>
		/// <example>
		/// ((byte)10).Hours().Ago();
		/// </example>
		public static TimeSpan Hours(this byte self)
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
		/// ((byte)1).Day().FromNow();
		/// </example>
		public static TimeSpan Day(this byte self)
		{
			return self.AsD().Day();
		}

		/// <summary>
		/// Returns value as a number of Days
		/// </summary>
		/// <param name="self">The value</param>
		/// <example>
		/// ((byte)10).Days().Ago();
		/// </example>
		public static TimeSpan Days(this byte self)
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
		/// ((byte)1).Week().FromNow();
		/// </example>
		public static TimeSpan Week(this byte self)
		{
			return self.AsD().Week();
		}

		/// <summary>
		/// Returns value as a number of Weeks
		/// </summary>
		/// <param name="self">The value</param>
		/// <example>
		/// ((byte)10).Weeks().Ago();
		/// </example>
		public static TimeSpan Weeks(this byte self)
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
		/// ((byte)1).Month().FromNow();
		/// </example>
		/// <seealso cref="Months"/>
		public static TimeSpan Month(this byte self)
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
		/// ((byte)10).Months().Ago();
		/// </example>
		public static TimeSpan Months(this byte self)
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
		/// ((byte)1).Year().FromNow();
		/// </example>
		/// <seealso cref="Years"/>
		public static TimeSpan Year(this byte self)
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
		/// ((byte)10).Years().Ago();
		/// </example>
		public static TimeSpan Years(this byte self)
		{
			return self.AsD().Years();
		}
	}
}
