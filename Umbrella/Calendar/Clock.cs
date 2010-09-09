using nVentive.Umbrella.Locator;

namespace nVentive.Umbrella.Calendar
{
	public static class Clock
	{
		public static global::System.DateTime Now
		{
			get { return _Clock.Now;	}
		}

		public static global::System.DateTime UtcNow
		{
			get { return _Clock.UtcNow; }
		}

		public static global::System.DateTime Today
		{
			get { return _Clock.Today; }
		}

		private static IClock _Clock
		{
			get
			{
				return 
					// TryResolve will return null if it can't resolve
					ServiceLocator.Instance.TryResolve<IClock>() 
					?? 
					SystemClock.Instance;
			}
		}
	}
}
