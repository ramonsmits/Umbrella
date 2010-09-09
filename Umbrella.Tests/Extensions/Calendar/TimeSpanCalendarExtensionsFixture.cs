using System;
using nVentive.Umbrella.Calendar;
using nVentive.Umbrella.Extensions;
using nVentive.Umbrella.Extensions.Calendar;
using nVentive.Umbrella.Locator;
using nVentive.Umbrella.Tests.Clock;
using Xunit;
using XunitExt;

namespace nVentive.Umbrella.Tests.Extensions.Calendar
{
	public class TimeSpanCalendarExtensionsFixture
	{
		private class FreezingClockLocator : IServiceLocator
		{
			public bool CanResolve(Type type, string name)
			{
				return type.Is<IClock>();
			}

			public object Resolve(Type type, string name)
			{
				return FreezingClock.Instance;
			}
		}

		[Fact]
		[FreezeClock(2008, 10, 31, 10, 00, 00, DateTimeKind.Local)]
		public void FromNow()
		{
			using(ThreadLocalServiceLocator.Push(new FreezingClockLocator()))
			{
				var future = 10.Days().FromNow();
				var now = TimeSpanCalendarExtensions.Extensions.Now;

				Assert.Equal(future, now.AddDays(10));
				Assert.Equal(DateTimeKind.Local, future.Kind);
			}
		}

		[Fact]
		[FreezeClock(2008, 10, 31, 10, 00, 00, DateTimeKind.Utc)]
		public void FromNowUTC()
		{
			using (ThreadLocalServiceLocator.Push(new FreezingClockLocator()))
			{
				var future = 10.Days().FromNow(DateTimeKind.Utc);
				var now = TimeSpanCalendarExtensions.Extensions.UtcNow;

				Assert.Equal(future, now.AddDays(10));
				Assert.Equal(DateTimeKind.Utc, future.Kind);
			}
		}

		[Fact]
		[FreezeClock(2008, 10, 31, 10, 00, 00, DateTimeKind.Local)]
		public void Ago()
		{
			using (ThreadLocalServiceLocator.Push(new FreezingClockLocator()))
			{
				var past = 10.Days().Ago();
				var now = TimeSpanCalendarExtensions.Extensions.Now;

				Assert.Equal(past, now.Subtract(TimeSpan.FromDays(10)));
				Assert.Equal(DateTimeKind.Local, past.Kind);
			}
		}

		[Fact]
		[FreezeClock(2008, 10, 31, 10, 00, 00, DateTimeKind.Local)]
		public void AgoUTC()
		{
			using (ThreadLocalServiceLocator.Push(new FreezingClockLocator()))
			{
				var past = 10.Days().Ago(DateTimeKind.Utc);
				var now = TimeSpanCalendarExtensions.Extensions.UtcNow;

				Assert.Equal(past, now.Subtract(TimeSpan.FromDays(10)));
				Assert.Equal(DateTimeKind.Utc, past.Kind);
			}
		}
	}
}
