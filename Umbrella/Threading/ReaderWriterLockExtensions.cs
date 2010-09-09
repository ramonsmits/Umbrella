using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using Nventive.Framework.Threading;

namespace Nventive.Framework.Extensions
{
    public static class ReaderWriterLockExtensions
    {
        public static IReaderWriterLockExtensions Extensions
        {
            get { return ExtensionsProvider.GetExtensions<IReaderWriterLockExtensions, DefaultReaderWriterLockExtensions>(); }
        }

        public static T Read<T>(this ReaderWriterLock instance, Func<T> func)
        {
            return Extensions.Read<T>(instance, func);
        }

        public static T Read<T>(this ReaderWriterLock instance, int millisecondsTimeout, Func<T> func)
        {
            return Extensions.Read<T>(instance, millisecondsTimeout, func);
        }

        public static bool Write(this ReaderWriterLock instance, Func<bool> read, Action write)
        {
            return Extensions.Write(instance, read, write);
        }

        public static bool Write(this ReaderWriterLock instance, int millisecondsTimeout, Func<bool> read, Action write)
        {
            return Extensions.Write(instance, millisecondsTimeout, read, write);
        }
    }
}
