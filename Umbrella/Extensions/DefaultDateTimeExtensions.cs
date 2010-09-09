using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using nVentive.Umbrella.Extensions.ValueType;

namespace nVentive.Umbrella.Extensions
{
    public class DefaultDateTimeExtensions : IDateTimeExtensions
    {
        #region IDateTimeExtensions Members

        public virtual bool IsWeekEnd(DateTime instance)
        {
        }

        public virtual bool IsWeekDay(DateTime instance)
        {
        }

        public virtual bool Equal(DateTime lhs, DateTime rhs, DateTimeUnit unit)
        {
        }

        public virtual DateTime Truncate(DateTime instance, DateTimeUnit unit)
        {
        }

        #endregion
    }
}
