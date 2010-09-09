using System;
using nVentive.Umbrella.Extensions.Calendar;
using Xunit;

namespace nVentive.Umbrella.Tests.Extensions.Calendar
{
	public class DefaultDateTimeCalendarExtensionsFixture
	{
		[Fact]
		public void WeekBeginsOn()
		{
			var def = new DefaultDateTimeCalendarExtensions();
			Assert.Equal(DayOfWeek.Monday, def.WeekBeginsOn);
		}

		[Fact]
		public void WeekEndsOn()
		{
			var def = new DefaultDateTimeCalendarExtensions();
			Assert.Equal(DayOfWeek.Sunday, def.WeekEndsOn);
		}

		[Fact]
		public void QuarterMonths()
		{
			var def = new DefaultDateTimeCalendarExtensions();

			Assert.Contains(1, def.QuarterMonths);
			Assert.Contains(4, def.QuarterMonths);
			Assert.Contains(7, def.QuarterMonths);
			Assert.Contains(10, def.QuarterMonths);
		}
	}
}
