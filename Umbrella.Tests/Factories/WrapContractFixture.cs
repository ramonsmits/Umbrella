using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using nVentive.Umbrella.Factories;

namespace nVentive.Framework.Tests.Factories
{
    public class WrapContractFixture
    {
        [Fact]
        public void Ctor()
        {
            object instance = new object();
            var contract = new WrapContract(instance);

            Assert.Same(instance, contract.Value);
        }
    }
}
