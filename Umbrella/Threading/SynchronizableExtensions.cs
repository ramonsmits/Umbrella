using System;
using nVentive.Umbrella.Threading;

namespace nVentive.Umbrella.Extensions
{
    public static class SynchronizableExtensions
    {
        public static void Read<T>(this ISynchronizableLock<T> sync, Action<T> read)
        {
            Read<T, Null>(sync, item =>
                                    {
                                        read(item);
                                        return null;
                                    });
        }

        public static void Write<T>(this ISynchronizableLock<T> sync, Action<T> write)
        {
            Write<T, Null>(sync, item =>
                                     {
                                         write(item);
                                         return null;
                                     });
        }

        public static TValue Write<T, TValue>(this ISynchronizableLock<T> sync, Func<T, TValue> write)
        {
            return sync.Write(-1, write);
        }

        public static TValue Read<T, TValue>(this ISynchronizableLock<T> sync, Func<T, TValue> read)
        {
            return sync.Read(-1, read);
        }

        public static bool Write<T>(this ISynchronizableLock<T> sync, Func<T, bool> read, Action<T> write)
        {
            return sync.Write(-1, read, write);
        }

        public static IDisposable CreateReaderScope<T>(this ISynchronizableLock<T> sync)
        {
            return sync.CreateReaderScope(-1);
        }

        public static IDisposable CreateWriterScope<T>(this ISynchronizableLock<T> sync)
        {
            return sync.CreateWriterScope(-1);
        }

#if !SILVERLIGHT
        public static IDisposable CreateReleaseScope<T>(this ISynchronizableLock<T> sync)
        {
            return sync.CreateReleaseScope(-1);
        }
#endif
    }
}