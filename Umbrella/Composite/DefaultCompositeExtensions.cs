using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nVentive.Umbrella.Composite
{
    public class DefaultCompositeExtensions : ICompositeExtensions
    {
        public IEnumerable<T> SelectMany<T>(IComposite<T> composite)
        {
            foreach (T item in composite.Items.SelectMany<T, T>(SelectMany))
            {
                yield return item;
            }
        }

        public IEnumerable<T> SelectMany<T>(T instance)
        {
            IComposite<T> composite = instance as IComposite<T>;

            if (composite == null)
            {
                yield return instance;
            }
            else
            {
                foreach (T item in SelectMany<T>(composite))
                {
                    yield return item;
                }
            }
        }
    }
}
