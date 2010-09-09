using nVentive.Umbrella.Locator;

namespace nVentive.Umbrella.Components
{
    public interface IComponent
    {
        IServiceLocator ServiceLocator { get; set; }
    }
}