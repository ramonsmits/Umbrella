using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nVentive.Umbrella.Extensions;

namespace nVentive.Umbrella.Decorator
{
    public class DefaultDecoratorExtensions : IDecoratorExtensions
    {
        #region IDecoratorExtensions Members

        public T As<T>(IDecorator<T> decorator)
        {
        }

        #endregion
    }
}
