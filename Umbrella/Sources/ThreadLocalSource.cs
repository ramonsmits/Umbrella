using System;
using System.Linq;
using System.Collections.Generic;
using nVentive.Umbrella.Extensions;
using System.Threading;

namespace nVentive.Umbrella.Sources
{
    public static class ThreadLocalSource
    {
        public static ISource<T> New<T>()
            where T : new()
        {
            return new LazySource<T>(
                new ThreadLocalSource<T>(),
                LazyBehavior.Default,
                () => new T());
        }
    }

    public class ThreadLocalSource<T> : ISource<T>
    {
#if !SILVERLIGHT
        [ThreadStatic]
        private static IDictionary<string, T> values;
#else
        private static Tuple<WeakReference, IDictionary<string, T>>[] _tls = new Tuple<WeakReference, IDictionary<string, T>>[0];
#endif

        public ThreadLocalSource()
            : this(Guid.NewGuid().ToString())
        {
        }

        public ThreadLocalSource(T value)
            : this(Guid.NewGuid().ToString(), value)
        {
        }

        public ThreadLocalSource(string name)
        {
            Name = name;
        }

        public ThreadLocalSource(string name, T value)
            : this(name)
        {
            // TODO: We should not call virtual members in the contructor
            Value = value;
        }

        public string Name { get; private set; }

        #region ISource<T> Members

        public virtual T Value
        {
            get { return Values.GetValueOrDefault(Name); }
            set { Values[Name] = value; }
        }

        #endregion

#if !SILVERLIGHT
        protected virtual IDictionary<string, T> Values
        {
            get
            {
               if (values == null)
                {
                    values = new Dictionary<string, T>();
                }

                return values;
            }
        }
#else
        protected virtual IDictionary<string, T> Values
        {
            get
            {
                return GetValuesForThread(Thread.CurrentThread);
            }
        }

        private static IDictionary<string, T> GetValuesForThread(Thread thread)
        {
            var query = from entry in _tls
                        let t = entry.T.Target as Thread
                        where t != null && t == thread
                        select entry.U;

            var localStorage = query.FirstOrDefault();

            if (localStorage == null)
            {
                bool success = false;

                localStorage = new Dictionary<string, T>();

                while(!success)
                {
                    var localCopy = _tls;

                    var newTls = new List<Tuple<WeakReference, IDictionary<string, T>>>();

                    // Add the slots for which threads are still alive
                    newTls.AddRange(_tls.Where(t => t.T.IsAlive));

                    var newSlot = new Tuple<WeakReference, IDictionary<string, T>>()
                    {
                        T = new WeakReference(thread),
                        U = localStorage
                    };

                    newTls.Add(newSlot);

                    // If no other thread has changed the array, replace it.
                    success = Interlocked.CompareExchange(ref _tls, newTls.ToArray(), localCopy) != _tls;
                }
            }

            return localStorage;
        }
#endif
    }
}