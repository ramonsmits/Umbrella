using System;

namespace nVentive.Umbrella
{
    [Flags]
    public enum DateTimeUnit
    {
        Year = 1,
        Month = 2,
        Day = 4,
        Hour = 8,
        Minute = 16,
        Second = 32,
        Millisecond = 64,
        ToMonth = Year | Month,
        ToDay = ToMonth | Day,
        ToHour = ToDay | Hour,
        ToMinute = ToHour | Minute,
        ToSecond = ToMinute | Second,
        ToMillisecond = ToSecond | Millisecond
    }
}