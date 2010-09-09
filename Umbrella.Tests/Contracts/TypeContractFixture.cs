using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using nVentive.Umbrella.Contracts;

namespace nVentive.Framework.Tests.Contracts
{
    public class TypeContractFixture
    {
        [Fact]
        public void Ctor()
        {
            var contract = new TypeContract();

            Assert.Null(contract.Value);
        }
    }
}
