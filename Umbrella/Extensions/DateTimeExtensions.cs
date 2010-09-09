using System;
using nVentive.Umbrella.Extensions.ValueType;

namespace nVentive.Umbrella.Extensions
{
    public static class DateTimeExtensions
    {
        public static bool IsWeekEnd(this DateTime instance)
        {
            return instance.DayOfWeek == DayOfWeek.Saturday ||
                   instance.DayOfWeek == DayOfWeek.Sunday;
        }

        public static bool IsWeekDay(this DateTime instance)
        {
            return !IsWeekEnd(instance);
        }

        public static bool Equal(this DateTime lhs, DateTime rhs, DateTimeUnit unit)
        {
            if (unit.ContainsAll(DateTimeUnit.Year))
            {
                if (lhs.Year != rhs.Year)
                {
                    return false;
                }
            }

            if (unit.ContainsAll(DateTimeUnit.Month))
            {
                if (lhs.Month != rhs.Month)
                {
                    return false;
                }
            }

            if (unit.ContainsAll(DateTimeUnit.Day))
            {
                if (lhs.Day != rhs.Day)
                {
                    return false;
                }
            }

            if (unit.ContainsAll(DateTimeUnit.Hour))
            {
                if (lhs.Hour != rhs.Hour)
                {
                    return false;
                }
            }

            if (unit.ContainsAll(DateTimeUnit.Minute))
            {
                if (lhs.Minute != rhs.Minute)
                {
                    return false;
                }
            }

            if (unit.ContainsAll(DateTimeUnit.Second))
            {
                if (lhs.Second != rhs.Second)
                {
                    return false;
                }
            }

            if (unit.ContainsAll(DateTimeUnit.Millisecond))
            {
                if (lhs.Millisecond != rhs.Millisecond)
                {
                    return false;
                }
            }

            return true;
        }

        public static DateTime Truncate(this DateTime instance, DateTimeUnit unit)
        {
            var year = unit.ContainsAll(DateTimeUnit.Year) ? instance.Year : 1;
            var month = unit.ContainsAll(DateTimeUnit.Month) ? instance.Month : 1;
            var day = unit.ContainsAll(DateTimeUnit.Day) ? instance.Day : 1;
            var hour = unit.ContainsAll(DateTimeUnit.Hour) ? instance.Hour : 0;
            var minute = unit.ContainsAll(DateTimeUnit.Minute) ? instance.Minute : 0;
            var second = unit.ContainsAll(DateTimeUnit.Second) ? instance.Second : 0;
            var millisecond = unit.ContainsAll(DateTimeUnit.Millisecond) ? instance.Millisecond : 0;

            return new DateTime(year, month, day, hour, minute, second, millisecond, instance.Kind);
        }

        public static DateTime AddWeeks(this DateTime dateTime, int weeks)
        {
            return dateTime.AddDays(weeks * 7);
        }
    }
}