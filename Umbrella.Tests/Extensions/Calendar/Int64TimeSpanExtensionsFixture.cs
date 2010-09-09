using nVentive.Umbrella.Extensions.Calendar;
using Xunit;

namespace nVentive.Umbrella.Tests.Extensions.Calendar
{
	public class Int64TimeSpanExtensionsFixture
	{
		private readonly long value = 10L;

		[Fact]
		public void Ticks()
		{
			var span = value.Ticks();
			Assert.Equal(value, span.Ticks);

			var span2 = value.Tick();
			Assert.Equal(value, span2.Ticks);
		}

		[Fact]
		public void Milliseconds()
		{
			var span = value.Milliseconds();
			Assert.Equal(value, span.Milliseconds);

			var span2 = value.Millisecond();
			Assert.Equal(value, span2.Milliseconds);
		}

		[Fact]
		public void Seconds()
		{
			var span = value.Seconds();
			Assert.Equal(value, span.Seconds);

			var span2 = value.Second();
			Assert.Equal(value, span2.Seconds);
		}

		[Fact]
		public void Minutes()
		{
			var span = value.Minutes();
			Assert.Equal(value, span.Minutes);

			var span2 = value.Minute();
			Assert.Equal(value, span2.Minutes);
		}

		[Fact]
		public void Hours()
		{
			var span = value.Minutes();
			Assert.Equal(value, span.Minutes);

			var span2 = value.Minute();
			Assert.Equal(value, span2.Minutes);
		}

		[Fact]
		public void Days()
		{
			var span = value.Days();
			Assert.Equal(value, span.Days);

			var span2 = value.Day();
			Assert.Equal(value, span2.Days);
		}

		[Fact]
		public void Weeks()
		{
			var span = value.Weeks();
			Assert.Equal(value * 7D, span.Days);

			var span2 = value.Week();
			Assert.Equal(value * 7D, span2.Days);
		}

		[Fact]
		public void Months()
		{
			var span = value.Months();
			Assert.Equal(value * 30D, span.Days);

			var span2 = value.Month();
			Assert.Equal(value * 30D, span2.Days);
		}

		[Fact]
		public void Years()
		{
			var span = value.Years();
			Assert.Equal(value * 365D, span.Days);

			var span2 = value.Year();
			Assert.Equal(value * 365D, span2.Days);
		}
	}
}
