using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nVentive.Umbrella.Composite
{
    public interface ICompositeExtensions
    {
        IEnumerable<T> SelectMany<T>(IComposite<T> composite);
        IEnumerable<T> SelectMany<T>(T instance);
    }
}
