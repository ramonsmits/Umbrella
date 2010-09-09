using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nVentive.Umbrella.Extensions
{
    //TODO Use Extensions Pattern.
    public static class IteratorExtensions
    {
        public static bool Contains<T>(this Func<T, T> iterator, T item, Func<T, bool> predicate)
            where T : class
        {
            return Contains<T>(item, iterator, predicate);
        }

        //TODO Useful or use extension version?
        public static bool Contains<T>(T item, Func<T, T> iterator, Func<T, bool> predicate)
            where T : class
        {
            return Find<T>(item, iterator, predicate) != null;
        }

        public static T Find<T>(T item, Func<T, T> iterator, Func<T, bool> predicate)
            where T : class
        {
            T current = item;

            while (current != null)
            {
                if (predicate(current))
                {
                    return current;
                }

                current = iterator(current);
            }

            return null;
        }

        //TODO Complete. Also implement ForEach(Many) with Func<T, IEnumerable<T>>
        //public static void ForEach<T>(this Func<T, T> iterator, T item, Action<T> action)
        //{
        //    iterator.ForEach<T>(item
        //}

        //public static void ForEach<T>(this Func<T, T> iterator, T item, Func<T, bool> predicate, Action<T> action)
        //{
        //    T current = item;

        //    while (!predicate(current))
        //    {
        //        action(current);

        //        current = iterator(current);
        //    }
        //}
    }
}
