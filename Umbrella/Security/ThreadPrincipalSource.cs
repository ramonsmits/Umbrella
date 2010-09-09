using System.Security.Principal;
using System.Threading;
using nVentive.Umbrella.Sources;

namespace nVentive.Umbrella.Security
{
    public class ThreadPrincipalSource : ISource<IPrincipal>
    {
        #region ISource<IPrincipal> Members

        public IPrincipal Value
        {
            get { return Thread.CurrentPrincipal; }
            set { Thread.CurrentPrincipal = value; }
        }

        #endregion
    }
}