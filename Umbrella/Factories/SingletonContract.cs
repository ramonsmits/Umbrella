using nVentive.Umbrella.Contracts;

namespace nVentive.Umbrella.Factories
{
    // TODO: make thread safe
    public class SingletonContract : IContract
    {
        public static readonly IContract Instance = new SingletonContract();

        private SingletonContract()
        {
        }
    }
}