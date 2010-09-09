using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nVentive.Umbrella.Extensions
{
    public interface IDateTimeExtensions
    {
        bool IsWeekEnd(DateTime instance);
        bool IsWeekDay(DateTime instance);

        //TODO Change to DateTimeUnitContract?
        bool Equal(DateTime lhs, DateTime rhs, DateTimeUnit unit);
        
        DateTime Truncate(DateTime instance, DateTimeUnit unit);
        //TODO Support overloads with nullable?
    }
}
