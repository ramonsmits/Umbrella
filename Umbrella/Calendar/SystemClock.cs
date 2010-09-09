using System;

namespace nVentive.Umbrella.Calendar
{
	public sealed class SystemClock : IClock
	{
		public static readonly IClock Instance = new SystemClock();

		public global::System.DateTime Now
		{
			get { return global::System.DateTime.Now; }
		}

		public global::System.DateTime UtcNow
		{
			get { return global::System.DateTime.UtcNow; }
		}

		public global::System.DateTime Today
		{
			get { return global::System.DateTime.Today; }
		}
	}
}
