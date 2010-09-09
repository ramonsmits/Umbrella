using System;

namespace nVentive.Umbrella.Locator
{
    public interface IServiceLocator
    {
        bool CanResolve(Type type, string name);
        object Resolve(Type type, string name);
    }
}