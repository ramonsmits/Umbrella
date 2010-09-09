using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LocatedClock = nVentive.Umbrella.Calendar.Clock;

namespace nVentive.Umbrella.Extensions.Calendar
{
	public class DefaultDateTimeCalendarExtensions : IDateTimeCalendarExtensions
	{
		private static readonly int[] QUARTER_MONTHS = { 10, 7, 4, 1 };

		public virtual DateTime Now
		{
			get { return LocatedClock.Now; }
		}

		public virtual DateTime UtcNow
		{
			get { return LocatedClock.UtcNow; }
		}

		public virtual DateTime Today
		{
			get { return LocatedClock.Today; }
		}

		public virtual DayOfWeek WeekBeginsOn
		{
			get { return DayOfWeek.Monday; }
		}

		public virtual DayOfWeek WeekEndsOn
		{
			get { return DayOfWeek.Sunday; }
		}

		public virtual IEnumerable<int> QuarterMonths
		{
			get { return QUARTER_MONTHS; }
		}
	}
}
