using System.Security.Principal;
using System.Web;
using nVentive.Umbrella.Sources;

namespace nVentive.Umbrella.Web
{
    public class WebPrincipalSource : ISource<IPrincipal>
    {
        #region ISource<IPrincipal> Members

        public IPrincipal Value
        {
            get { return HttpContext.Current.User; }
            set { HttpContext.Current.User = value; }
        }

        #endregion
    }
}