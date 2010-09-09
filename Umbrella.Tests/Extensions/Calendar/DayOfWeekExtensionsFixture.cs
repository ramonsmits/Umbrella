using System;
using nVentive.Umbrella.Extensions.Calendar;
using Xunit;

namespace nVentive.Umbrella.Tests.Extensions.Calendar
{
	public class DayOfWeekExtensionsFixture
	{
		[Fact]
		public void DaysTillTest()
		{
			Assert.Equal(1, DayOfWeek.Sunday.DaysTill(DayOfWeek.Monday));
			Assert.Equal(2, DayOfWeek.Sunday.DaysTill(DayOfWeek.Tuesday));
			Assert.Equal(3, DayOfWeek.Sunday.DaysTill(DayOfWeek.Wednesday));
			Assert.Equal(4, DayOfWeek.Sunday.DaysTill(DayOfWeek.Thursday));
			Assert.Equal(5, DayOfWeek.Sunday.DaysTill(DayOfWeek.Friday));
			Assert.Equal(6, DayOfWeek.Sunday.DaysTill(DayOfWeek.Saturday));
			Assert.Equal(7, DayOfWeek.Sunday.DaysTill(DayOfWeek.Sunday));

			Assert.Equal(5, DayOfWeek.Wednesday.DaysTill(DayOfWeek.Monday));
			Assert.Equal(6, DayOfWeek.Wednesday.DaysTill(DayOfWeek.Tuesday));
			Assert.Equal(7, DayOfWeek.Wednesday.DaysTill(DayOfWeek.Wednesday));
			Assert.Equal(1, DayOfWeek.Wednesday.DaysTill(DayOfWeek.Thursday));
			Assert.Equal(2, DayOfWeek.Wednesday.DaysTill(DayOfWeek.Friday));
			Assert.Equal(3, DayOfWeek.Wednesday.DaysTill(DayOfWeek.Saturday));
			Assert.Equal(4, DayOfWeek.Wednesday.DaysTill(DayOfWeek.Sunday));

			Assert.Equal(3, DayOfWeek.Friday.DaysTill(DayOfWeek.Monday));
			Assert.Equal(4, DayOfWeek.Friday.DaysTill(DayOfWeek.Tuesday));
			Assert.Equal(5, DayOfWeek.Friday.DaysTill(DayOfWeek.Wednesday));
			Assert.Equal(6, DayOfWeek.Friday.DaysTill(DayOfWeek.Thursday));
			Assert.Equal(7, DayOfWeek.Friday.DaysTill(DayOfWeek.Friday));
			Assert.Equal(1, DayOfWeek.Friday.DaysTill(DayOfWeek.Saturday));
			Assert.Equal(2, DayOfWeek.Friday.DaysTill(DayOfWeek.Sunday));

			var dt1 = DateTime.Now;
			var dt2 = dt1.AddDays(2);
			Assert.Equal(2, dt1.DayOfWeek.DaysTill(dt2.DayOfWeek));
		}

		[Fact]
		public void DaysSinceTest()
		{
			Assert.Equal(6, DayOfWeek.Sunday.DaysSince(DayOfWeek.Monday));
			Assert.Equal(5, DayOfWeek.Sunday.DaysSince(DayOfWeek.Tuesday));
			Assert.Equal(4, DayOfWeek.Sunday.DaysSince(DayOfWeek.Wednesday));
			Assert.Equal(3, DayOfWeek.Sunday.DaysSince(DayOfWeek.Thursday));
			Assert.Equal(2, DayOfWeek.Sunday.DaysSince(DayOfWeek.Friday));
			Assert.Equal(1, DayOfWeek.Sunday.DaysSince(DayOfWeek.Saturday));
			Assert.Equal(7, DayOfWeek.Sunday.DaysSince(DayOfWeek.Sunday));

			Assert.Equal(2, DayOfWeek.Wednesday.DaysSince(DayOfWeek.Monday));
			Assert.Equal(1, DayOfWeek.Wednesday.DaysSince(DayOfWeek.Tuesday));
			Assert.Equal(7, DayOfWeek.Wednesday.DaysSince(DayOfWeek.Wednesday));
			Assert.Equal(6, DayOfWeek.Wednesday.DaysSince(DayOfWeek.Thursday));
			Assert.Equal(5, DayOfWeek.Wednesday.DaysSince(DayOfWeek.Friday));
			Assert.Equal(4, DayOfWeek.Wednesday.DaysSince(DayOfWeek.Saturday));
			Assert.Equal(3, DayOfWeek.Wednesday.DaysSince(DayOfWeek.Sunday));

			Assert.Equal(4, DayOfWeek.Friday.DaysSince(DayOfWeek.Monday));
			Assert.Equal(3, DayOfWeek.Friday.DaysSince(DayOfWeek.Tuesday));
			Assert.Equal(2, DayOfWeek.Friday.DaysSince(DayOfWeek.Wednesday));
			Assert.Equal(1, DayOfWeek.Friday.DaysSince(DayOfWeek.Thursday));
			Assert.Equal(7, DayOfWeek.Friday.DaysSince(DayOfWeek.Friday));
			Assert.Equal(6, DayOfWeek.Friday.DaysSince(DayOfWeek.Saturday));
			Assert.Equal(5, DayOfWeek.Friday.DaysSince(DayOfWeek.Sunday));

			var dt1 = DateTime.Now;
			var dt2 = dt1.AddDays(2);
			Assert.Equal(2, dt2.DayOfWeek.DaysSince(dt1.DayOfWeek));
		}

		[Fact]
		public void RangeCheckTests()
		{
			var dows = new[]
			{ 
				DayOfWeek.Sunday, DayOfWeek.Monday, DayOfWeek.Tuesday, 
				DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday, 
				DayOfWeek.Saturday 
			};

			Array.ForEach(dows, (d) => Assert.True(d.InRange()));
			Array.ForEach(dows, (d) => Assert.DoesNotThrow(() => d.CheckRange()));

			var dow = (DayOfWeek)100;
			Assert.False(dow.InRange());
			Assert.Throws<ArgumentOutOfRangeException>(() => dow.CheckRange());
		}
	}
}
