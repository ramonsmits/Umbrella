using nVentive.Umbrella.Contracts;

namespace nVentive.Umbrella.Security
{
    public interface IAuthorizationService
    {
        bool IsAuthorized(IContract contract);
    }
}