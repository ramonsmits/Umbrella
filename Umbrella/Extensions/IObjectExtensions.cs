using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nVentive.Umbrella.Extensions
{
    public interface IObjectExtensions
    {
        ExtensionPoint<T> Extensions<T>(T instance);

        bool IsDefault<T>(ExtensionPoint<T> extensionPoint);

        IDisposable Using<T>(ExtensionPoint<T> extensionPoint);
        void Dispose<T>(ExtensionPoint<T> extensionPoint);

        //TODO ToString(ExtensionPoint<T> extensionPoint, Func<T, IEnumerable<object>> fieldsEnumerator);
    }
}
