using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using nVentive.Umbrella.Extensions;

namespace nVentive.Umbrella.Locator
{
    public static class ThreadLocalServiceLocator
    {
        [ThreadStatic]
        private static Stack<IServiceLocator> instances;

        public static IServiceLocator Instance
        {
            get { return Instances.PeekOrDefault(); }
        }

        public static bool IsLoaded
        {
            get { return Instances.Any(); }
        }

        public static IDisposable Push(IServiceLocator locator)
        {
            return Instances.Subscribe(locator);
        }

        public static Stack<IServiceLocator> Instances
        {
            get
            {
                if (instances == null) // Prevent creating a Stack<IServiceLocator> if instances is not null
                    Interlocked.CompareExchange(ref instances, new Stack<IServiceLocator>(), null); 
                return instances;
            }
        }
    }
}