using nVentive.Umbrella.Locator;

namespace nVentive.Umbrella.Extensions
{
    public static class ExtensionsProvider
    {
        public static TService Get<TService, TConcrete>()
            where TConcrete : TService, new()
        {
            var service = ServiceLocator.Instance.TryResolve<TService>();

            // TODO: service might not be null
            if (service == null)
            {
                service = new TConcrete();
            }

            return service;
        }
    }
}