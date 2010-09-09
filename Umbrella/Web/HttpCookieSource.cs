using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nventive.Framework.Sources;
using System.Web;

namespace Nventive.Framework.Web
{
    public class HttpCookieSource : ISource<string>
    {
        public HttpCookieSource(string name)
        {
            Name = name;
        }

        public string Name
        {
            get;
            set;
        }

        #region ISource<string> Members

        public string Value
        {
            get { return HttpContext.Current.Request.Cookies[Name].Value; }
            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion
    }
}
