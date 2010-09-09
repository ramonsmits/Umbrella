using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nVentive.Framework
{
    public delegate IEnumerable EnumerableProvider<T>(T instance);
}
