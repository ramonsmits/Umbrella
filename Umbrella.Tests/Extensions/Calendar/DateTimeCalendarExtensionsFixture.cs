using System;
using nVentive.Umbrella.Extensions.Calendar;
using Xunit;

namespace nVentive.Umbrella.Tests.Extensions.Calendar
{
	public class DateTimeCalendarExtensionsFixture
	{
		[Fact]
		public void BeginningOfDayTest()
		{
			// June 12th is a thursday...
			var dt = NewDT(2008, 6, 12, 15, 43, 10);

			var dt2 = dt.BeginningOfDay();
			Assert.Equal(6, dt2.Month);
			Assert.Equal(DayOfWeek.Thursday, dt2.DayOfWeek);
			Assert.Equal(12, dt2.Day);
			Assert.Equal(dt.Kind, dt2.Kind);

			TimeShouldBeZeroedOutAsWell(dt2);
		}

		[Fact]
		public void EndOfDayTest()
		{
			// June 12th is a thursday...
			var dt = NewDT(2008, 6, 12, 15, 43, 10);

			var dt2 = dt.EndOfDay();
			Assert.Equal(6, dt2.Month);
			Assert.Equal(DayOfWeek.Thursday, dt2.DayOfWeek);
			Assert.Equal(12, dt2.Day);
			Assert.Equal(dt.Kind, dt2.Kind);

			TimeShouldBeEndOfDay(dt2);
		}

		[Fact]
		public void BeginningOfWeekTest()
		{
			// June 12th is a thursday...
			var dt = NewDT(2008, 6, 12, 15, 43, 10);

			var dt2 = dt.BeginningOfWeek();
			Assert.Equal(6, dt2.Month);
			Assert.Equal(DayOfWeek.Monday, dt2.DayOfWeek);
			Assert.Equal(9, dt2.Day);
			Assert.Equal(dt.Kind, dt2.Kind);

			TimeShouldBeZeroedOutAsWell(dt2);
		}

		[Fact]
		public void EndOfWeekTest()
		{
			// June 12th is a thursday...
			var dt = NewDT(2008, 6, 12, 15, 43, 10);

			var dt2 = dt.EndOfWeek();
			Assert.Equal(6, dt2.Month);
			Assert.Equal(DayOfWeek.Sunday, dt2.DayOfWeek);
			Assert.Equal(15, dt2.Day);
			Assert.Equal(dt.Kind, dt2.Kind);

			TimeShouldBeEndOfDay(dt2);
		}

		[Fact]
		public void BeginningOfMonthTest()
		{
			// June 12th is a thursday...
			var dt = NewDT(2008, 6, 12, 15, 43, 10);

			var dt2 = dt.BeginningOfMonth();
			Assert.Equal(6, dt2.Month);
			Assert.Equal(DayOfWeek.Sunday, dt2.DayOfWeek);
			Assert.Equal(1, dt2.Day);
			Assert.Equal(dt.Kind, dt2.Kind);

			TimeShouldBeZeroedOutAsWell(dt2);
		}

		[Fact]
		public void EndOfMonthTest()
		{
			// June 12th is a thursday...
			var dt = NewDT(2008, 6, 12, 15, 43, 10);
			var dt2 = dt.EndOfMonth();
			Assert.Equal(6, dt2.Month);
			Assert.Equal(DayOfWeek.Monday, dt2.DayOfWeek);
			Assert.Equal(30, dt2.Day);
			Assert.Equal(dt.Kind, dt2.Kind);
			TimeShouldBeEndOfDay(dt2);
		}

		[Fact]
		public void EndOfMonthForLeapYearTest()
		{
			// make sure leap years work...
			var dt = NewDT(2008, 2, 1, 23, 45, 10);
			var dt2 = dt.EndOfMonth();
			Assert.Equal(2, dt2.Month);
			Assert.Equal(DayOfWeek.Friday, dt2.DayOfWeek);
			Assert.Equal(29, dt2.Day);
			Assert.Equal(dt.Kind, dt2.Kind);
			TimeShouldBeEndOfDay(dt2);
		}

		[Fact]
		public void EndOfMonthForNonLeapYearTest()
		{
			// make sure leap years work...
			var dt = NewDT(2007, 2, 1, 23, 45, 10);
			var dt2 = dt.EndOfMonth();
			Assert.Equal(2, dt2.Month);
			Assert.Equal(DayOfWeek.Wednesday, dt2.DayOfWeek);
			Assert.Equal(28, dt2.Day);
			Assert.Equal(dt.Kind, dt2.Kind);
			TimeShouldBeEndOfDay(dt2);
		}

		[Fact]
		public void BeginningOfQuarterTest()
		{
			// June 12th is a thursday...
			var dt = NewDT(2008, 6, 12, 15, 43, 10);
			var dt2 = dt.BeginningOfQuarter();
			Assert.Equal(4, dt2.Month);
			Assert.Equal(DayOfWeek.Tuesday, dt2.DayOfWeek);
			Assert.Equal(1, dt2.Day);
			Assert.Equal(dt.Kind, dt2.Kind);
			TimeShouldBeZeroedOutAsWell(dt2);

			// April 4th is a Friday
			dt = NewDT(2008, 4, 4, 15, 43, 10);
			dt2 = dt.BeginningOfQuarter();
			Assert.Equal(4, dt2.Month);
			Assert.Equal(DayOfWeek.Tuesday, dt2.DayOfWeek);
			Assert.Equal(1, dt2.Day);
			Assert.Equal(dt.Kind, dt2.Kind);
			TimeShouldBeZeroedOutAsWell(dt2);

			// Feb 14th is a Thursday
			dt = NewDT(2008, 2, 14, 15, 43, 10);
			dt2 = dt.BeginningOfQuarter();
			Assert.Equal(1, dt2.Month);
			Assert.Equal(DayOfWeek.Tuesday, dt2.DayOfWeek);
			Assert.Equal(1, dt2.Day);
			Assert.Equal(dt.Kind, dt2.Kind);
			TimeShouldBeZeroedOutAsWell(dt2);

			// Dec 21st is a Sunday
			dt = NewDT(2008, 12, 21, 15, 43, 10);
			dt2 = dt.BeginningOfQuarter();
			Assert.Equal(10, dt2.Month);
			Assert.Equal(DayOfWeek.Wednesday, dt2.DayOfWeek);
			Assert.Equal(1, dt2.Day);
			Assert.Equal(dt.Kind, dt2.Kind);
			TimeShouldBeZeroedOutAsWell(dt2);
		}

		[Fact]
		public void EndOfQuarterTest()
		{
			// June 12th is a thursday...
			var dt = NewDT(2008, 6, 12, 15, 43, 10);
			var dt2 = dt.EndOfQuarter();
			Assert.Equal(7, dt2.Month);
			Assert.Equal(DayOfWeek.Thursday, dt2.DayOfWeek);
			Assert.Equal(31, dt2.Day);
			Assert.Equal(dt.Kind, dt2.Kind);
			TimeShouldBeEndOfDay(dt2);

			// April 4th is a Friday
			dt = NewDT(2008, 4, 4, 15, 43, 10);
			dt2 = dt.EndOfQuarter();
			Assert.Equal(7, dt2.Month);
			Assert.Equal(DayOfWeek.Thursday, dt2.DayOfWeek);
			Assert.Equal(31, dt2.Day);
			Assert.Equal(dt.Kind, dt2.Kind);
			TimeShouldBeEndOfDay(dt2);

			// Feb 14th is a Thursday
			dt = NewDT(2008, 2, 14, 15, 43, 10);
			dt2 = dt.EndOfQuarter();
			Assert.Equal(4, dt2.Month);
			Assert.Equal(DayOfWeek.Wednesday, dt2.DayOfWeek);
			Assert.Equal(30, dt2.Day);
			Assert.Equal(dt.Kind, dt2.Kind);
			TimeShouldBeEndOfDay(dt2);

			// Dec 21st is a Sunday
			dt = NewDT(2008, 12, 21, 15, 43, 10);
			dt2 = dt.EndOfQuarter();
			Assert.Equal(12, dt2.Month);
			Assert.Equal(DayOfWeek.Wednesday, dt2.DayOfWeek);
			Assert.Equal(31, dt2.Day);
			Assert.Equal(dt.Kind, dt2.Kind);
			TimeShouldBeEndOfDay(dt2);
		}

		[Fact]
		public void BeginningOfYearTest()
		{
			// June 12th is a thursday...
			var dt = NewDT(2008, 6, 12, 15, 43, 10);
			var dt2 = dt.BeginningOfYear();
			Assert.Equal(1, dt2.Month);
			Assert.Equal(DayOfWeek.Tuesday, dt2.DayOfWeek);
			Assert.Equal(1, dt2.Day);
			Assert.Equal(dt.Kind, dt2.Kind);
			TimeShouldBeZeroedOutAsWell(dt2);
		}

		[Fact]
		public void EndOfYearTest()
		{
			// June 12th is a thursday...
			var dt = NewDT(2008, 6, 12, 15, 43, 10);
			var dt2 = dt.EndOfYear();
			Assert.Equal(12, dt2.Month);
			Assert.Equal(DayOfWeek.Wednesday, dt2.DayOfWeek);
			Assert.Equal(31, dt2.Day);
			Assert.Equal(dt.Kind, dt2.Kind);
			TimeShouldBeEndOfDay(dt2);
		}

		[Fact]
		public void TomorrowTest()
		{
			// June 12th is a thursday...
			var dt = NewDT(2008, 6, 12, 15, 43, 10);
			var t = dt.Tomorrow();
			Assert.Equal(6, t.Month);
			Assert.Equal(DayOfWeek.Friday, t.DayOfWeek);
			Assert.Equal(13, t.Day);
			Assert.Equal(dt.Kind, t.Kind);
			TimeShouldBeEqual(dt, t);
		}

		[Fact]
		public void ChainedTomorrowTest()
		{
			// June 12th is a thursday...
			var dt = NewDT(2008, 6, 12, 15, 43, 10);
			var t = dt.Tomorrow().Tomorrow().Tomorrow();
			Assert.Equal(6, t.Month);
			Assert.Equal(DayOfWeek.Sunday, t.DayOfWeek);
			Assert.Equal(15, t.Day);
			Assert.Equal(dt.Kind, t.Kind);
			TimeShouldBeEqual(dt, t);
		}

		[Fact]
		public void YesterdayTest()
		{
			// June 12th is a thursday...
			var dt = NewDT(2008, 6, 12, 15, 43, 10);
			var y = dt.Yesterday();
			Assert.Equal(6, y.Month);
			Assert.Equal(DayOfWeek.Wednesday, y.DayOfWeek);
			Assert.Equal(11, y.Day);
			Assert.Equal(dt.Kind, y.Kind);
			TimeShouldBeEqual(dt, y);
		}

		[Fact]
		public void NextDayTest()
		{
			// June 12th is a thursday...
			var dt = NewDT(2008, 6, 12, 15, 43, 10);
			var n = dt.NextDay(DayOfWeek.Monday);
			Assert.Equal(6, n.Month);
			Assert.Equal(DayOfWeek.Monday, n.DayOfWeek);
			Assert.Equal(16, n.Day);
			Assert.Equal(dt.Kind, n.Kind);
			TimeShouldBeEqual(dt, n);
		}

		[Fact]
		public void NextDayWithLeapYearTest()
		{
			// April 28th is a Thursday
			var dt = NewDT(2008, 2, 28, 10, 10, 10);
			var n = dt.NextDay(DayOfWeek.Friday);
			Assert.Equal(2, n.Month);
			Assert.Equal(DayOfWeek.Friday, n.DayOfWeek);
			Assert.Equal(29, n.Day);
			Assert.Equal(dt.Kind, n.Kind);
			TimeShouldBeEqual(dt, n);

			// April 28th is a Wednesday
			dt = NewDT(2007, 2, 28, 10, 10, 10);
			n = dt.NextDay(DayOfWeek.Thursday);
			Assert.Equal(3, n.Month);
			Assert.Equal(DayOfWeek.Thursday, n.DayOfWeek);
			Assert.Equal(1, n.Day);
			Assert.Equal(dt.Kind, n.Kind);
			TimeShouldBeEqual(dt, n);
		}

		[Fact]
		public void NextDayAtMonthBoundaryTest()
		{
			// April 30th is a Wednesday
			var dt = NewDT(2008, 4, 30, 12, 12, 12);
			var n = dt.NextDay(DayOfWeek.Tuesday);
			Assert.Equal(5, n.Month);
			Assert.Equal(DayOfWeek.Tuesday, n.DayOfWeek);
			Assert.Equal(6, n.Day);
			Assert.Equal(dt.Kind, n.Kind);
			TimeShouldBeEqual(dt, n);
		}

		[Fact]
		public void NextDayAtYearBoundaryTest()
		{
			// end of 2008 is a Wednesday
			var dt = NewDT(2008, 12, 31).EndOfDay();
			var n = dt.NextDay(DayOfWeek.Thursday);
			Assert.Equal(1, n.Month);
			Assert.Equal(DayOfWeek.Thursday, n.DayOfWeek);
			Assert.Equal(1, n.Day);
			Assert.Equal(2009, n.Year);
			Assert.Equal(dt.Kind, n.Kind);
			TimeShouldBeEqual(dt, n);
		}

		[Fact]
		public void NextHelperTest()
		{
			// April 7 is a Monday...
			var dt = NewDT(2008, 4, 7, 12, 34, 45);

			var next = dt.NextTuesday();
			Assert.Equal(DayOfWeek.Tuesday, next.DayOfWeek);
			Assert.Equal(8, next.Day);
			Assert.Equal(dt.Kind, next.Kind);

			next = dt.NextWednesday();
			Assert.Equal(DayOfWeek.Wednesday, next.DayOfWeek);
			Assert.Equal(9, next.Day);
			Assert.Equal(dt.Kind, next.Kind);

			next = dt.NextThursday();
			Assert.Equal(DayOfWeek.Thursday, next.DayOfWeek);
			Assert.Equal(10, next.Day);
			Assert.Equal(dt.Kind, next.Kind);

			next = dt.NextFriday();
			Assert.Equal(DayOfWeek.Friday, next.DayOfWeek);
			Assert.Equal(11, next.Day);
			Assert.Equal(dt.Kind, next.Kind);

			next = dt.NextSaturday();
			Assert.Equal(DayOfWeek.Saturday, next.DayOfWeek);
			Assert.Equal(12, next.Day);
			Assert.Equal(dt.Kind, next.Kind);

			next = dt.NextSunday();
			Assert.Equal(DayOfWeek.Sunday, next.DayOfWeek);
			Assert.Equal(13, next.Day);
			Assert.Equal(dt.Kind, next.Kind);

			next = dt.NextMonday();
			Assert.Equal(DayOfWeek.Monday, next.DayOfWeek);
			Assert.Equal(14, next.Day);
			Assert.Equal(dt.Kind, next.Kind);
		}

		[Fact]
		public void PrevHelperTest()
		{
			// April 14 is a Monday...
			var dt = NewDT(2008, 4, 14, 12, 34, 45);

			var prev = dt.PreviousTuesday();
			Assert.Equal(DayOfWeek.Tuesday, prev.DayOfWeek);
			Assert.Equal(8, prev.Day);
			Assert.Equal(dt.Kind, prev.Kind);

			prev = dt.PreviousWednesday();
			Assert.Equal(DayOfWeek.Wednesday, prev.DayOfWeek);
			Assert.Equal(9, prev.Day);
			Assert.Equal(dt.Kind, prev.Kind);

			prev = dt.PreviousThursday();
			Assert.Equal(DayOfWeek.Thursday, prev.DayOfWeek);
			Assert.Equal(10, prev.Day);
			Assert.Equal(dt.Kind, prev.Kind);

			prev = dt.PreviousFriday();
			Assert.Equal(DayOfWeek.Friday, prev.DayOfWeek);
			Assert.Equal(11, prev.Day);
			Assert.Equal(dt.Kind, prev.Kind);

			prev = dt.PreviousSaturday();
			Assert.Equal(DayOfWeek.Saturday, prev.DayOfWeek);
			Assert.Equal(12, prev.Day);
			Assert.Equal(dt.Kind, prev.Kind);

			prev = dt.PreviousSunday();
			Assert.Equal(DayOfWeek.Sunday, prev.DayOfWeek);
			Assert.Equal(13, prev.Day);
			Assert.Equal(dt.Kind, prev.Kind);

			prev = dt.PreviousMonday();
			Assert.Equal(DayOfWeek.Monday, prev.DayOfWeek);
			Assert.Equal(7, prev.Day);
			Assert.Equal(dt.Kind, prev.Kind);
		}

		[Fact]
		public void PreviousDayTest()
		{
			// June 12th is a thursday...
			var dt = NewDT(2008, 6, 12, 15, 43, 10);
			var p = dt.PreviousDay(DayOfWeek.Monday);
			Assert.Equal(6, p.Month);
			Assert.Equal(DayOfWeek.Monday, p.DayOfWeek);
			Assert.Equal(9, p.Day);
			TimeShouldBeEqual(dt, p);
		}

		[Fact]
		public void PreviousDayWithLeapYearTest()
		{
			// March 3rd 2008 is a Monday
			var dt = NewDT(2008, 3, 3, 12, 34, 12);
			var p = dt.PreviousDay(DayOfWeek.Friday);
			Assert.Equal(2, p.Month);
			Assert.Equal(DayOfWeek.Friday, p.DayOfWeek);
			Assert.Equal(29, p.Day);
			TimeShouldBeEqual(dt, p);

			// March 3rd 2007 is a Saturday
			dt = NewDT(2007, 3, 3, 12, 34, 12);
			p = dt.PreviousDay(DayOfWeek.Wednesday);
			Assert.Equal(2, p.Month);
			Assert.Equal(DayOfWeek.Wednesday, p.DayOfWeek);
			Assert.Equal(28, p.Day);
			TimeShouldBeEqual(dt, p);
		}

		[Fact]
		public void PreviousDayAtMonthBoundaryTest()
		{
			// April 1st is a tuesday
			var dt = NewDT(2008, 4, 1, 12, 34, 54);
			var p = dt.PreviousDay(DayOfWeek.Wednesday);
			Assert.Equal(3, p.Month);
			Assert.Equal(DayOfWeek.Wednesday, p.DayOfWeek);
			Assert.Equal(26, p.Day);
			TimeShouldBeEqual(dt, p);
		}

		[Fact]
		public void PreviousDayAtYearBoundaryTest()
		{
			// Jan 1 2008 is a Tuesday
			var dt = NewDT(2008, 1, 1, 23, 43, 12);
			var p = dt.PreviousDay(DayOfWeek.Sunday);
			Assert.Equal(12, p.Month);
			Assert.Equal(DayOfWeek.Sunday, DayOfWeek.Sunday);
			Assert.Equal(30, p.Day);
			Assert.Equal(2007, p.Year);
			TimeShouldBeEqual(dt, p);
		}

		private static readonly Random randDtKind = new Random();

		private static DateTime NewDT(int year, int month, int day)
		{
			var kind = randDtKind.Next(1) == 1 ? DateTimeKind.Local : DateTimeKind.Utc;
			return DateTime.SpecifyKind(new DateTime(year, month, day), kind);
		}

		private static DateTime NewDT(int year, int month, int day, int hour, int minute, int second)
		{
			var kind = randDtKind.Next(2) == 1 ? DateTimeKind.Local : DateTimeKind.Utc;
			return new DateTime(year, month, day, hour, minute, second, kind);
		}

		private static void TimeShouldBeZeroedOutAsWell(DateTime dt)
		{
			// the time should be zeroed out as well...
			Assert.Equal(0, dt.Hour);
			Assert.Equal(0, dt.Minute);
			Assert.Equal(0, dt.Second);
			Assert.Equal(0, dt.Millisecond);
		}

		private static void TimeShouldBeEndOfDay(DateTime dt)
		{
			Assert.Equal(23, dt.Hour);
			Assert.Equal(59, dt.Minute);
			Assert.Equal(59, dt.Second);
			Assert.Equal(0, dt.Millisecond);
		}

		private static void TimeShouldBeEqual(DateTime expected, DateTime actual)
		{
			Assert.Equal(expected.Hour, actual.Hour);
			Assert.Equal(expected.Minute, actual.Minute);
			Assert.Equal(expected.Second, actual.Second);
			Assert.Equal(expected.Millisecond, actual.Millisecond);
		}
	}
}
