using System;
using Umbrella;

namespace nVentive.Umbrella.Threading
{
    [Serializable]
    public class Synchronizable<T> : ISynchronizable<T>
    {
        private readonly ISynchronizableLock<T> syncLock;

        public Synchronizable(T instance)
        {
            syncLock = new SynchronizableLock<T>(instance);
        }

        #region ISynchronizable<T> Members

        public ISynchronizableLock<T> Lock
        {
            get { return syncLock; }
        }

        #endregion
    }
}