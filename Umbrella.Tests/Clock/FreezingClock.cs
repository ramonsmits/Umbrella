using System;
using nVentive.Umbrella.Calendar;
using XClock = XunitExt.Clock;

namespace nVentive.Umbrella.Tests.Clock
{
	class FreezingClock : IClock
	{
		public static readonly IClock Instance = new FreezingClock();

		public DateTime Now
		{
			get { return XClock.Now; }
		}

		public DateTime UtcNow
		{
			get { return XClock.UtcNow; }
		}

		public DateTime Today
		{
			get { return XClock.Today; }
		}
	}
}
