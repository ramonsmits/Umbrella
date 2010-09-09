using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nVentive.Umbrella.Decorator
{
    public interface IDecoratorExtensions
    {
        T As<T>(IDecorator<T> decorator);
    }
}
