using nVentive.Umbrella.Contracts;

namespace nVentive.Umbrella.Factories
{
    public interface IFactory
    {
        object Create(IContract contract);
    }
}