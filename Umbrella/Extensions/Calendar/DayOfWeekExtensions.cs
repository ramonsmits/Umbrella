using System;

namespace nVentive.Umbrella.Extensions.Calendar
{
	public static class DayOfWeekExtensions
	{
		private const int SATURDAY = (int)DayOfWeek.Saturday;

		/// <summary>
		/// Determines whether or not the DayOfWeek instance is a valid DayOfWeek.
		/// </summary>
		/// <param name="self">The DayOfWeek to check</param>
		/// <returns>true if valid value, false otherwise</returns>
		public static bool InRange(this DayOfWeek self)
		{
			return self >= DayOfWeek.Sunday && self <= DayOfWeek.Saturday;
		}

		/// <summary>
		/// Determines whether or not the DayOfWeek instance is a valid DayOfWeek
		/// </summary>
		/// <param name="self">The DayOfWeek to check</param>
		/// <exception cref="ArgumentOutOfRangeException">If DayOfWeek value isn't a valid value</exception>
		public static void CheckRange(this DayOfWeek self)
		{
			if (!self.InRange())
#if !SILVERLIGHT
				throw new ArgumentOutOfRangeException("DayOfWeek", self, "DayOfWeek out of Range");
#else
				throw new ArgumentOutOfRangeException("DayOfWeek", "DayOfWeek out of Range");
#endif
		}

		/// <summary>
		/// Determines the number of days from one DayOfWeek till the next.
		/// </summary>
		/// <param name="self">the starting DayOfWeek</param>
		/// <param name="next">The ending DayOfWeek</param>
		/// <returns>the number of days from <paramref name="self"/> to <paramref name="next"/></returns>
		/// <exception cref="ArgumentOutOfRangeException">If either DayOfWeek is not 
		/// <see cref="DayOfWeekExtensions.InRange"/></exception>
		/// <example>
		/// Debug.Assert(DayOfWeek.Monday.DaysTill(DayOfWeek.Tuesday) == 1);
		/// </example>
		public static int DaysTill(this DayOfWeek self, DayOfWeek next)
		{
			self.CheckRange();
			next.CheckRange();

			return DaysBetween((int)next, (int)self);
		}

		/// <summary>
		/// Determines the number of days since one DayOfWeek since the previous.
		/// </summary>
		/// <param name="self">the starting DayOfWeek</param>
		/// <param name="prev">The previous DayOfWeek</param>
		/// <returns>the number of days since <paramref name="self"/> to <paramref name="prev"/></returns>
		/// <exception cref="ArgumentOutOfRangeException">If either DayOfWeek is not 
		/// <see cref="DayOfWeekExtensions.InRange"/></exception>
		/// <example>
		/// Debug.Assert(DayOfWeek.Tuesday.DaysSince(DayOfWeek.Monday) == 1);
		/// </example>
		public static int DaysSince(this DayOfWeek self, DayOfWeek prev)
		{
			self.CheckRange();
			prev.CheckRange();

			return DaysBetween((int)self, (int)prev);
		}

		private static int DaysBetween(int first, int second)
		{
			if (first > second)
			{
				return first - second;
			}

			return SATURDAY - (second - first) + 1;
		}
	}
}
