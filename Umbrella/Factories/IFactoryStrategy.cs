using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nVentive.Umbrella.Contracts;

namespace nVentive.Umbrella.Factories
{
    public interface IFactoryStrategy : IFactory
    {
        bool Fulfill(IContract contract);
    }
}
