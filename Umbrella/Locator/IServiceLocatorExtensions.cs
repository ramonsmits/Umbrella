using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nVentive.Umbrella.Locator
{
    public interface IServiceLocatorExtensions
    {
        T Find<T>(IServiceLocator locator);
        T Find<T>(IServiceLocator locator, string name);
        object Find(IServiceLocator locator, Type type);
    }
}
