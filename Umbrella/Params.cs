using System.Collections.Generic;

namespace nVentive.Umbrella
{
    public static class Params
    {
        public static IEnumerable<T> AsEnumerable<T>(params T[] values)
        {
            return values;
        }
    }
}