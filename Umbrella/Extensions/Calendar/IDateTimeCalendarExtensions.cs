using System;
using System.Collections.Generic;

namespace nVentive.Umbrella.Extensions.Calendar
{
	public interface IDateTimeCalendarExtensions
	{
		DateTime Now { get; }

		DateTime UtcNow { get; }

		DateTime Today { get; }

		DayOfWeek WeekBeginsOn { get; }

		DayOfWeek WeekEndsOn { get; }

		IEnumerable<int> QuarterMonths { get; }
	}
}
