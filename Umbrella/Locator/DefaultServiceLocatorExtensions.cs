using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nVentive.Umbrella.Locator
{
    public class DefaultServiceLocatorExtensions : IServiceLocatorExtensions
    {
        #region IServiceLocatorExtensions Members

        public T Find<T>(IServiceLocator locator)
        {
        }

        public T Find<T>(IServiceLocator locator, string name)
        {
        }

        public object Find(IServiceLocator locator, Type type)
        {
        }

        #endregion
    }
}
