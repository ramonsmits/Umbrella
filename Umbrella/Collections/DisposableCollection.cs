using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace Nventive.Framework.Collections
{
    public class DisposableCollection<T> : Collection<T>, IDisposable
    {
        #region IDisposable Members

        public virtual void Dispose()
        {
            foreach (T item in this)
            {

            }
        }

        #endregion
    }
}
