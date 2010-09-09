using System.Security;
using nVentive.Umbrella.Contracts;

namespace nVentive.Umbrella.Security
{
    public static class AuthorizationServiceExtensions
    {
        public static bool IsAuthorized(this IAuthorizationService service, string context)
        {
            return service.IsAuthorized(new NameContract(context));
        }

        public static void Authorize(this IAuthorizationService service, string context)
        {
            if (!IsAuthorized(service, context))
            {
                throw new SecurityException();
            }
        }
    }
}