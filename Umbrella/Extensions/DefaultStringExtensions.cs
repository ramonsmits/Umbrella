using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nVentive.Umbrella.Extensions
{
    public class DefaultStringExtensions : IStringExtensions
    {
        #region IStringExtensions Members

        public virtual bool IsNullOrEmpty(string instance)
        {
        }

        public virtual bool HasValue(string instance)
        {
        }

        public virtual bool IsNumber(string instance)
        {
        }

        public virtual bool IsDigit(string instance)
        {
        }


        public virtual string JoinBy(IEnumerable<string> items, string joinBy)
        {
        }

        #endregion
    }
}
