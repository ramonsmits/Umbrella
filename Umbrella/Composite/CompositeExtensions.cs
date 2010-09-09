using System.Collections.Generic;
using System.Linq;
using nVentive.Umbrella.Composite;

namespace nVentive.Umbrella.Extensions
{
    public static class CompositeExtensions
    {
        public static IEnumerable<T> SelectMany<T>(this IComposite<T> composite)
        {
            foreach (var item in composite.Items.SelectMany<T, T>(SelectMany))
            {
                yield return item;
            }
        }

        public static IEnumerable<T> SelectMany<T>(T instance)
        {
            var composite = instance as IComposite<T>;

            if (composite == null)
            {
                yield return instance;
            }
            else
            {
                foreach (var item in SelectMany(composite))
                {
                    yield return item;
                }
            }
        }
    }
}