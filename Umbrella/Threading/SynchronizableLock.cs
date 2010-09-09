using System;
using System.Threading;
using nVentive.Umbrella.Extensions;
using System.Runtime.Serialization;
using Umbrella;

namespace nVentive.Umbrella.Threading
{
    [Serializable]
    public class SynchronizableLock<T> : ISynchronizableLock<T>
    {
        private readonly T instance;
        //TODO Use Slim Lock?
        [NonSerialized]
        private ReaderWriterLock readerWriter = new ReaderWriterLock();

        public SynchronizableLock(T instance)
        {
            this.instance = instance;
        }

        #region ISynchronizableLock<T> Members

        public virtual TValue Read<TValue>(int millisecondsTimeout, Func<T, TValue> read)
        {
            readerWriter.AcquireReaderLock(millisecondsTimeout);

            try
            {
                return read(instance);
            }
            finally
            {
                readerWriter.ReleaseReaderLock();
            }
        }

#if !SILVERLIGHT
        public virtual void Release(Action<T> release)
        {
            var cookie = readerWriter.ReleaseLock();

            try
            {
                release(instance);
            }
            finally
            {
                readerWriter.RestoreLock(ref cookie);
            }
        }
#endif

        public virtual bool Write(int millisecondsTimeout, Func<T, bool> read, Action<T> write)
        {
            readerWriter.AcquireReaderLock(millisecondsTimeout);

            try
            {
                if (read(instance))
                {
                    return true;
                }
                else
                {
                    var cookie = readerWriter.UpgradeToWriterLock(millisecondsTimeout);

                    try
                    {
                        if (read(instance))
                        {
                            return true;
                        }
                        else
                        {
                            write(instance);
                        }
                    }
                    finally
                    {
                        readerWriter.DowngradeFromWriterLock(ref cookie);
                    }
                }
            }
            finally
            {
                readerWriter.ReleaseReaderLock();
            }

            return false;
        }

        public virtual TValue Write<TValue>(int millisecondsTimeout, Func<T, TValue> write)
        {
            readerWriter.AcquireWriterLock(millisecondsTimeout);

            try
            {
                return write(instance);
            }
            finally
            {
                readerWriter.ReleaseWriterLock();
            }
        }

        public virtual IDisposable CreateReaderScope(int millisecondsTimeout)
        {
            readerWriter.AcquireReaderLock(millisecondsTimeout);

            return Actions.Create(() => readerWriter.ReleaseReaderLock()).ToDisposable();
        }

        public virtual IDisposable CreateWriterScope(int millisecondsTimeout)
        {
            readerWriter.AcquireWriterLock(millisecondsTimeout);

            return Actions.Create(() => readerWriter.ReleaseWriterLock()).ToDisposable();
        }

#if !SILVERLIGHT
        public virtual IDisposable CreateReleaseScope(int millisecondsTimeout)
        {
            var cookie = readerWriter.ReleaseLock();

            return Actions.Create(() => readerWriter.RestoreLock(ref cookie)).ToDisposable();
        }
#endif

        #endregion

        #region Serialization Specific

        [OnDeserialized]
        internal void OnDeserializedMethod(StreamingContext context)
        {
            if(readerWriter == null)
                readerWriter = new ReaderWriterLock();
        }    
        #endregion
    }
}