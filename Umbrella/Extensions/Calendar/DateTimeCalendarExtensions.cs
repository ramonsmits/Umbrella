using System;
using System.Linq;

namespace nVentive.Umbrella.Extensions.Calendar
{
	public static class DateTimeCalendarExtensions
	{
		public static IDateTimeCalendarExtensions Extensions
		{
			get { return ExtensionsProvider.Get<IDateTimeCalendarExtensions, DefaultDateTimeCalendarExtensions>(); }
		}

		/// <summary>
		/// Returns a DateTime adjusted to the beginning of the day.
		/// </summary>
		/// <param name="self">The DateTime to adjust</param>
		/// <returns>A DateTime with the same date component, but a time component at the 
		/// beginning of the day - 00:00:00.</returns>
		public static DateTime BeginningOfDay(this DateTime self)
		{
			return self.Date.AsKind(self.Kind);
		}

		/// <summary>
		/// Returns a DateTime adjusted to the end of the day.
		/// </summary>
		/// <param name="self">The DateTime to adjust</param>
		/// <returns>A DateTime with the same date component, but a time component at the
		/// end of the day - 23:59:59</returns>
		public static DateTime EndOfDay(this DateTime self)
		{
			return 
				new DateTime(self.Year, self.Month, self.Day, 23, 59, 59)
						.AsKind(self.Kind);
		}

		/// <summary>
		/// Returns a DateTime adjusted to the beginning of the week.
		/// </summary>
		/// <param name="self">The DateTime to adjust</param>
		/// <returns>A DateTime instance adjusted to the beginning of the current week</returns>
		/// <remarks>the beginning of the week is controlled by IDateTimeCalenderExtensions.
		/// Provide an implementation in a <see cref="ServiceLocator"/> to override the
		/// default value of Monday</remarks>
		public static DateTime BeginningOfWeek(this DateTime self)
		{
			var daysSince = self.DayOfWeek.DaysSince(Extensions.WeekBeginsOn).Days();
			return
				(self - daysSince)
					.BeginningOfDay();
		}

		/// <summary>
		/// Returns a DateTime adjusted to the end of the week.
		/// </summary>
		/// <param name="self">The DateTime to adjust</param>
		/// <returns>A DateTime instance adjusted to the end of the current week</returns>
		/// <remarks>the end of the week is controlled by IDateTimeCalenderExtensions.
		/// Provide an implementation in a <see cref="ServiceLocator"/> to override the
		/// default value of Sunday</remarks>		
		public static DateTime EndOfWeek(this DateTime self)
		{
			var daysTill = self.DayOfWeek.DaysTill(Extensions.WeekEndsOn).Days();
			return
				(self + daysTill)
					.EndOfDay();
		}

		/// <summary>
		/// Returns a DateTime adjusted to the beginning of the month.
		/// </summary>
		/// <param name="self">The DateTime to adjust</param>
		/// <returns>A DateTime instance adjusted to the beginning of the current month</returns>
		public static DateTime BeginningOfMonth(this DateTime self)
		{
			return
				new DateTime(self.Year, self.Month, 1)
						.AsKind(self.Kind);
		}

		/// <summary>
		/// Returns a DateTime adjusted to the end of the month
		/// </summary>
		/// <param name="self">The DateTime to adjust</param>
		/// <returns>A DateTime instance adjusted to the end of the current month</returns>
		public static DateTime EndOfMonth(this DateTime self)
		{
			var daysInMonth = DateTime.DaysInMonth(self.Year, self.Month);

			// must use AsKind here as well even though EndOfDay calls it because
			// EndOfDay is being called on our new instance
			return
				new DateTime(self.Year, self.Month, daysInMonth)
						.EndOfDay()
						.AsKind(self.Kind);
		}

		/// <summary>
		/// Returns a DateTime adjusted to the beginning of the current quarter.
		/// </summary>
		/// <param name="self">The DateTime to adjust</param>
		/// <returns>A DateTime instance adjusted to the beginning of the current quarter</returns>
		/// <remarks>The months that are considered quarters are controlled by IDateTimeCalenderExtensions.
		/// Provide an implementation in a <see cref="ServiceLocator"/> to override the
		/// default value of January, April, July, and October</remarks>
		public static DateTime BeginningOfQuarter(this DateTime self)
		{
			var month = Extensions.QuarterMonths.Where(m => m <= self.Month).First();
			return
				new DateTime(self.Year, month, 1)
						.AsKind(self.Kind);
		}

		/// <summary>
		/// Returns a DateTime adjusted to the end of the current quarter.
		/// </summary>
		/// <param name="self">The DateTime to adjust</param>
		/// <returns>A DateTime instance adjusted to the beginning of the current quarter</returns>
		/// <remarks>The months that are considered quarters are controlled by IDateTimeCalenderExtensions.
		/// Provide an implementation in a <see cref="ServiceLocator"/> to override the
		/// default value of January, April, July, and October</remarks>
		public static DateTime EndOfQuarter(this DateTime self)
		{
			var month = Extensions.QuarterMonths
								.Reverse()
								.Where(m => m > self.Month)
								.DefaultIfEmpty(12)
								.First();

			var daysInMonth = DateTime.DaysInMonth(self.Year, month);

			// must use AsKind here as well even though EndOfDay calls it because
			// EndOfDay is being called on our new instance
			return
				new DateTime(self.Year, month, daysInMonth)
						.EndOfDay()
						.AsKind(self.Kind);
		}

		/// <summary>
		/// Returns a DateTime adjusted to the beginning of the current year.
		/// </summary>
		/// <param name="self">The DateTime to adjust</param>
		/// <returns>A DateTime instance adjusted to the beginning of the current year.</returns>
		public static DateTime BeginningOfYear(this DateTime self)
		{
			return
				new DateTime(self.Year, 1, 1)
						.AsKind(self.Kind);
		}

		/// <summary>
		/// Returns a DateTime adjusted to the end of the current year.
		/// </summary>
		/// <param name="self">The DateTime to adjust</param>
		/// <returns>A DateTime instance adjusted to the end of the current year.</returns>
		public static DateTime EndOfYear(this DateTime self)
		{
			// must use AsKind here as well even though EndOfDay calls it because
			// EndOfDay is being called on our new instance
			return
				new DateTime(self.Year, 12, 31)
						.EndOfDay()
						.AsKind(self.Kind);
		}

		/// <summary>
		/// Returns a DateTime that corresponds to the next DayOfWeek using self as the current day.
		/// </summary>
		/// <param name="self">The current DateTime</param>
		/// <param name="next">The day you want to move current to</param>
		/// <example>
		/// var thanksgiving = new DateTime(2008, 11, 27);
		/// var tuesdayAfterThanksgiving = thanksgiving.NextDay(DayOfWeek.Tuesday);
		/// Debug.Assert(tuesdayAfterThanksgiving.Month == 12);
		/// Debug.Assert(tuesdayAfterThanksgiving.Day == 2);
		/// </example>
		public static DateTime NextDay(this DateTime self, DayOfWeek next)
		{
			var daysTill = self.DayOfWeek.DaysTill(next).Days();
			return
				(self + daysTill)
					.AsKind(self.Kind);
		}

		/// <summary>
		/// Returns a DateTime that corresponds to the previous DayOfWeek using self as the current day.
		/// </summary>
		/// <param name="self">The current DateTime</param>
		/// <param name="next">The day you want to move current to</param>
		/// <example>
		/// var thanksgiving = new DateTime(2008, 11, 27);
		/// var tuesdayBeforeThanksgiving = thanksgiving.PreviousDay(DayOfWeek.Tuesday);
		/// Debug.Assert(tuesdayBeforeThanksgiving.Month == 11);
		/// Debug.Assert(tuesdayBeforeThanksgiving.Day == 25);
		/// </example>
		public static DateTime PreviousDay(this DateTime self, DayOfWeek prev)
		{
			var daysSince = self.DayOfWeek.DaysSince(prev).Days();
			return 
				(self - daysSince)
					.AsKind(self.Kind);
		}

		/// <summary>
		/// Returns a DateTime that corresponds to the next Monday using self as the current day.
		/// </summary>
		/// <param name="self">The current DateTime</param>
		/// <seealso cref="NextDay"/>
		public static DateTime NextMonday(this DateTime self)
		{
			return self.NextDay(DayOfWeek.Monday);
		}

		/// <summary>
		/// Returns a DateTime that corresponds to the previous Monday using self as the current day.
		/// </summary>
		/// <param name="self">The current DateTime</param>
		/// <seealso cref="PreviousDay"/>
		public static DateTime PreviousMonday(this DateTime self)
		{
			return self.PreviousDay(DayOfWeek.Monday);
		}

		/// <summary>
		/// Returns a DateTime that corresponds to the next Tuesday using self as the current day.
		/// </summary>
		/// <param name="self">The current DateTime</param>
		/// <seealso cref="NextDay"/>
		public static DateTime NextTuesday(this DateTime self)
		{
			return self.NextDay(DayOfWeek.Tuesday);
		}

		/// <summary>
		/// Returns a DateTime that corresponds to the previous Tuesday using self as the current day.
		/// </summary>
		/// <param name="self">The current DateTime</param>
		/// <seealso cref="PreviousDay"/>
		public static DateTime PreviousTuesday(this DateTime self)
		{
			return self.PreviousDay(DayOfWeek.Tuesday);
		}

		/// <summary>
		/// Returns a DateTime that corresponds to the next Wednesday using self as the current day.
		/// </summary>
		/// <param name="self">The current DateTime</param>
		/// <seealso cref="NextDay"/>
		public static DateTime NextWednesday(this DateTime self)
		{
			return self.NextDay(DayOfWeek.Wednesday);
		}

		/// <summary>
		/// Returns a DateTime that corresponds to the previous Wednesday using self as the current day.
		/// </summary>
		/// <param name="self">The current DateTime</param>
		/// <seealso cref="PreviousDay"/>
		public static DateTime PreviousWednesday(this DateTime self)
		{
			return self.PreviousDay(DayOfWeek.Wednesday);
		}

		/// <summary>
		/// Returns a DateTime that corresponds to the next Thursday using self as the current day.
		/// </summary>
		/// <param name="self">The current DateTime</param>
		/// <seealso cref="NextDay"/>
		public static DateTime NextThursday(this DateTime self)
		{
			return self.NextDay(DayOfWeek.Thursday);
		}

		/// <summary>
		/// Returns a DateTime that corresponds to the previous Thursday using self as the current day.
		/// </summary>
		/// <param name="self">The current DateTime</param>
		/// <seealso cref="PreviousDay"/>
		public static DateTime PreviousThursday(this DateTime self)
		{
			return self.PreviousDay(DayOfWeek.Thursday);
		}

		/// <summary>
		/// Returns a DateTime that corresponds to the next Friday using self as the current day.
		/// </summary>
		/// <param name="self">The current DateTime</param>
		/// <seealso cref="NextDay"/>
		public static DateTime NextFriday(this DateTime self)
		{
			return self.NextDay(DayOfWeek.Friday);
		}

		/// <summary>
		/// Returns a DateTime that corresponds to the previous Friday using self as the current day.
		/// </summary>
		/// <param name="self">The current DateTime</param>
		/// <seealso cref="PreviousDay"/>
		public static DateTime PreviousFriday(this DateTime self)
		{
			return self.PreviousDay(DayOfWeek.Friday);
		}

		/// <summary>
		/// Returns a DateTime that corresponds to the next Saturday using self as the current day.
		/// </summary>
		/// <param name="self">The current DateTime</param>
		/// <seealso cref="NextDay"/>
		public static DateTime NextSaturday(this DateTime self)
		{
			return self.NextDay(DayOfWeek.Saturday);
		}

		/// <summary>
		/// Returns a DateTime that corresponds to the previous Saturday using self as the current day.
		/// </summary>
		/// <param name="self">The current DateTime</param>
		/// <seealso cref="PreviousDay"/>
		public static DateTime PreviousSaturday(this DateTime self)
		{
			return self.PreviousDay(DayOfWeek.Saturday);
		}

		/// <summary>
		/// Returns a DateTime that corresponds to the next Sunday using self as the current day.
		/// </summary>
		/// <param name="self">The current DateTime</param>
		/// <seealso cref="NextDay"/>
		public static DateTime NextSunday(this DateTime self)
		{
			return self.NextDay(DayOfWeek.Sunday);
		}

		/// <summary>
		/// Returns a DateTime that corresponds to the previous Sunday using self as the current day.
		/// </summary>
		/// <param name="self">The current DateTime</param>
		/// <seealso cref="PreviousDay"/>
		public static DateTime PreviousSunday(this DateTime self)
		{
			return self.PreviousDay(DayOfWeek.Sunday);
		}

		/// <summary>
		/// Returns a DateTime a number of seconds in the future. 
		/// </summary>
		/// <param name="self">The DateTime to move</param>
		/// <param name="seconds">Number of seconds</param>
		/// <example>
		/// var now = DateTime.UtcNow;
		/// var nowPlus10 = now.SecondsSince(10);
		/// Debug.Assert((nowPlus10 - now).TotalSeconds == 10);
		/// </example>
		public static DateTime SecondsSince(this DateTime self, double seconds)
		{
			return self.AddSeconds(seconds);
		}

		/// <summary>
		/// Returns a DateTime a number of seconds in the past
		/// </summary>
		/// <param name="self">The DateTime to move</param>
		/// <param name="seconds">Number of seconds</param>
		/// <example>
		/// var now = DateTime.UtcNow;
		/// var nowMinus10 = now.SecondsAgo(10);
		/// Debug.Assert((now - nowMinus10).TotalSeconds == 10);
		/// </example>
		public static DateTime SecondsAgo(this DateTime self, double seconds)
		{
			return self.AddSeconds(-seconds);
		}

		/// <summary>
		/// Returns a DateTime a number of minutes in the future. 
		/// </summary>
		/// <param name="self">The DateTime to move</param>
		/// <param name="minutes">Number of minutes</param>
		public static DateTime MinutesSince(this DateTime self, double minutes)
		{
			return self.AddMinutes(minutes);
		}

		/// <summary>
		/// Returns a DateTime a number of minutes in the past
		/// </summary>
		/// <param name="self">The DateTime to move</param>
		/// <param name="minutes">Number of minutes</param>
		public static DateTime MinutesAgo(this DateTime self, double minutes)
		{
			return self.AddMinutes(-minutes);
		}

		/// <summary>
		/// Returns a DateTime a number of hours in the future. 
		/// </summary>
		/// <param name="self">The DateTime to move</param>
		/// <param name="hours">Number of hours</param>
		public static DateTime HoursSince(this DateTime self, double hours)
		{
			return self.AddHours(hours);
		}

		/// <summary>
		/// Returns a DateTime a number of hours in the past
		/// </summary>
		/// <param name="self">The DateTime to move</param>
		/// <param name="hours">Number of hours</param>
		public static DateTime HoursAgo(this DateTime self, double hours)
		{
			return self.AddHours(-hours);
		}

		/// <summary>
		/// Returns a DateTime a number of days in the future. 
		/// </summary>
		/// <param name="self">The DateTime to move</param>
		/// <param name="days">Number of days</param>
		public static DateTime DaysSince(this DateTime self, double days)
		{
			return self.AddDays(days);
		}

		/// <summary>
		/// Returns a DateTime a number of days in the past
		/// </summary>
		/// <param name="self">The DateTime to move</param>
		/// <param name="days">Number of days</param>
		public static DateTime DaysAgo(this DateTime self, double days)
		{
			return self.AddDays(-days);
		}

		/// <summary>
		/// Returns a DateTime a number of weeks in the future. 
		/// </summary>
		/// <param name="self">The DateTime to move</param>
		/// <param name="weeks">Number of weeks</param>
		public static DateTime WeeksSince(this DateTime self, double weeks)
		{
			return self.DaysSince(weeks * 7D);
		}

		/// <summary>
		/// Returns a DateTime a number of weeks in the past
		/// </summary>
		/// <param name="self">The DateTime to move</param>
		/// <param name="weeks">Number of weeks</param>
		public static DateTime WeeksAgo(this DateTime self, double weeks)
		{
			return self.DaysAgo(weeks * 7D);
		}

		/// <summary>
		/// Returns a DateTime a number of months in the future. 
		/// </summary>
		/// <param name="self">The DateTime to move</param>
		/// <param name="months">Number of months</param>
		public static DateTime MonthsSince(this DateTime self, int months)
		{
			return self.AddMonths(months);
		}

		/// <summary>
		/// Returns a DateTime a number of months in the past
		/// </summary>
		/// <param name="self">The DateTime to move</param>
		/// <param name="months">Number of months</param>
		public static DateTime MonthsAgo(this DateTime self, int months)
		{
			return self.AddMonths(-months);
		}

		/// <summary>
		/// Returns a DateTime a number of years in the future. 
		/// </summary>
		/// <param name="self">The DateTime to move</param>
		/// <param name="years">Number of years</param>
		public static DateTime YearsSince(this DateTime self, int years)
		{
			return self.AddYears(years);
		}

		/// <summary>
		/// Returns a DateTime a number of years in the past
		/// </summary>
		/// <param name="self">The DateTime to move</param>
		/// <param name="years">Number of years</param>
		public static DateTime YearsAgo(this DateTime self, int years)
		{
			return self.AddYears(-years);
		}

		/// <summary>
		/// Returns a DateTime 1 day in the future
		/// </summary>
		/// <param name="self">The DateTime to move</param>
		/// <seealso cref="DaysSince"/>
		public static DateTime Tomorrow(this DateTime self)
		{
			return self.DaysSince(1D);
		}

		/// <summary>
		/// Returns a DateTime 1 day in the past
		/// </summary>
		/// <param name="self">The DateTime to move</param>
		/// <seealso cref="DaysAgo"/>
		public static DateTime Yesterday(this DateTime self)
		{
			return self.DaysAgo(1D);
		}

		/// <summary>
		/// Returns a DateTime 1 week in the future
		/// </summary>
		/// <param name="self">The DateTime to move</param>
		/// <seealso cref="WeeksSince"/>
		public static DateTime NextWeek(this DateTime self)
		{
			return self.WeeksSince(1D);
		}

		/// <summary>
		/// Returns a DateTime 1 week in the past
		/// </summary>
		/// <param name="self">The DateTime to move</param>
		/// <seealso cref="WeeksAgo"/>
		public static DateTime LastWeek(this DateTime self)
		{
			return self.WeeksAgo(1D);
		}

		/// <summary>
		/// Returns a DateTime 1 month in the future
		/// </summary>
		/// <param name="self">The DateTime to move</param>
		/// <seealso cref="MonthsSince"/>
		public static DateTime NextMonth(this DateTime self)
		{
			return self.MonthsSince(1);
		}

		/// <summary>
		/// Returns a DateTime 1 month in the past
		/// </summary>
		/// <param name="self">The DateTime to move</param>
		/// <seealso cref="MonthsAgo"/>
		public static DateTime LastMonth(this DateTime self)
		{
			return self.MonthsAgo(1);
		}

		/// <summary>
		/// Returns a DateTime 1 year in the future
		/// </summary>
		/// <param name="self">The DateTime to move</param>
		/// <seealso cref="YearsSince"/>
		public static DateTime NextYear(this DateTime self)
		{
			return self.YearsSince(1);
		}

		/// <summary>
		/// Returns a DateTime 1 year in the past
		/// </summary>
		/// <param name="self">The DateTime to move</param>
		/// <seealso cref="YearsAgo"/>
		public static DateTime LastYear(this DateTime self)
		{
			return self.YearsAgo(1);
		}

		/// <summary>
		/// Returns a new DateTime with the same components, but different DateTimeKind
		/// </summary>
		/// <param name="self">The DateTime to convert</param>
		/// <param name="kind">The DateTimeKind to convert to</param>
		public static DateTime AsKind(this DateTime self, DateTimeKind kind)
		{
			return DateTime.SpecifyKind(self, kind);
		}
	}
}
