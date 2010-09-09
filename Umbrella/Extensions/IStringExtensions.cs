using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nVentive.Umbrella.Extensions
{
    public interface IStringExtensions
    {
        bool IsNullOrEmpty(string instance);
        
        bool HasValue(string instance);
        
        bool IsNumber(string instance);
        
        bool IsDigit(string instance);

        void Append(StringBuilder builder, string format, params object[] args);

        void AppendLine(StringBuilder builder, string format, params object[] args);

        string JoinBy(IEnumerable<string> items, string joinBy);

        //TODO RegEx: bool Matches(string instance, string pattern);, Equals Contract (Trim, Casing)
    }
}
