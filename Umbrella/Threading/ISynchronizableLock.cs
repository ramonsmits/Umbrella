using System;

namespace nVentive.Umbrella.Threading
{
    public interface ISynchronizableLock<T>
    {
        TValue Read<TValue>(int millisecondsTimeout, Func<T, TValue> read);

        TValue Write<TValue>(int millisecondsTimeout, Func<T, TValue> write);

        bool Write(int millisecondsTimeout, Func<T, bool> read, Action<T> write);

        IDisposable CreateReaderScope(int millisecondsTimeout);

        IDisposable CreateWriterScope(int millisecondsTimeout);

#if !SILVERLIGHT
        IDisposable CreateReleaseScope(int millisecondsTimeout);
#endif
    }
}