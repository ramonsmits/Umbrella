using System.Threading;

namespace nVentive.Umbrella.Locator
{
    public static class ServiceLocator
    {
        private static IServiceLocator instance;

        public static IServiceLocator Instance
        {
            get
            {
                if (ThreadLocalServiceLocator.IsLoaded)
                {
                    return ThreadLocalServiceLocator.Instance;
                }

                if (instance == null)
                    Interlocked.CompareExchange(ref instance, NullServiceLocator.Instance, null);

                return instance;
            }
            set
            {
                Interlocked.Exchange(ref instance, value);
            }
        }
    }
}