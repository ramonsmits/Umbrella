using System;
using System.Web;
using nVentive.Umbrella.Extensions;
using nVentive.Umbrella.Sources;

namespace nVentive.Umbrella.Web
{
    public class HttpSessionSource<T> : ISource<T>
    {
        private readonly string key;

        public HttpSessionSource(string key)
        {
            this.key = key.Validation().NotNull("key");
        }

        #region ISource<T> Members

        public virtual T Value
        {
            get { return HttpContext.Current.Session == null ? default(T) : (T) HttpContext.Current.Session[key]; }
            set
            {
                if (HttpContext.Current.Session == null)
                {
                    throw new InvalidOperationException("Session not present");
                }
                
                HttpContext.Current.Session[key] = value;
            }
        }

        #endregion
    }
}