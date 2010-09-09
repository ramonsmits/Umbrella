using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nventive.Framework.Extensions
{
    public class TypedExtensionPoint<T> : ExtensionPoint<T>, ITypedExtensionPoint<T>
    {
        private Type type;

        public TypedExtensionPoint(Type type)
            : base(default(T))
        {
            this.type = type;
        }

        public TypedExtensionPoint(T value)
            : base(value)
        {
        }

        #region ITypedExtensionPoint<T> Members

        public Type Type
        {
            get { return type ?? typeof(T); }
        }

        #endregion
    }
}
