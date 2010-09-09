using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Nventive.Framework.Threading
{
    public interface IReaderWriterLockExtensions
    {
        T Read<T>(ReaderWriterLock instance, Func<T> func);
        T Read<T>(ReaderWriterLock instance, int millisecondsTimeout, Func<T> func);
        
        bool Write(ReaderWriterLock instance, Func<bool> read, Action write);
        bool Write(ReaderWriterLock instance, int millisecondsTimeout, Func<bool> read, Action write);
    }
}
