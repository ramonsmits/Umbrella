using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using nVentive.Umbrella.Collections;
using nVentive.Umbrella.Conversion;

namespace nVentive.Umbrella.Extensions
{
    public class DefaultObjectExtensions : IObjectExtensions
    {
        public virtual ExtensionPoint<T> Extensions<T>(T value)
        {
        }

        public virtual bool IsDefault<T>(ExtensionPoint<T> extensionPoint)
        {
        }

        public virtual IDisposable Using<T>(ExtensionPoint<T> extensionPoint)
        {
        }

        public virtual void Dispose<T>(ExtensionPoint<T> extensionPoint)
        {
        }
    }
}
