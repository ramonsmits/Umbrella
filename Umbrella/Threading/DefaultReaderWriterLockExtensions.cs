using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Nventive.Framework.Threading
{
    public class DefaultReaderWriterLockExtensions : IReaderWriterLockExtensions
    {
        #region IReaderWriterLockExtensions Members

        public virtual T Read<T>(ReaderWriterLock instance, Func<T> func)
        {
            return Read(instance, -1, func);
        }

        public virtual T Read<T>(ReaderWriterLock instance, int millisecondsTimeout, Func<T> func)
        {
            instance.AcquireReaderLock(millisecondsTimeout);

            try
            {
                return func();
            }
            finally
            {
                instance.ReleaseReaderLock();
            }
        }

        public virtual bool Write(ReaderWriterLock instance, Func<bool> read, Action write)
        {
            return Write(instance, -1, read, write);
        }

        public virtual bool Write(ReaderWriterLock instance, int millisecondsTimeout, Func<bool> read, Action write)
        {
            instance.AcquireReaderLock(millisecondsTimeout);

            try
            {
                if (read())
                {
                    return true;
                }
                else
                {
                    LockCookie cookie = instance.UpgradeToWriterLock(millisecondsTimeout);

                    try
                    {
                        if (read())
                        {
                            return true;
                        }
                        else
                        {
                            write();
                        }
                    }
                    finally
                    {
                        instance.DowngradeFromWriterLock(ref cookie);
                    }
                }
            }
            finally
            {
                instance.ReleaseReaderLock();
            }

            return false;
        }

        #endregion
    }
}
