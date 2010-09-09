using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using nVentive.Umbrella;
using nVentive.Umbrella.Factories;

namespace nVentive.Framework.Tests.Factories
{
    public class ArgumentsContractFixture
    {
        [Fact]
        public void Ctor()
        {
            IEnumerable<object> items = Params.AsEnumerable<object>(1, "2");

            var contract = new ArgumentsContract(items);

            Assert.Same(items, contract.Value);
        }
    }
}
