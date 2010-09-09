using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using nVentive.Umbrella.Contracts;

namespace nVentive.Framework.Tests.Contracts
{
    public class NameContractFixture
    {
        [Fact]
        public void Ctor()
        {
            var contract = new NameContract();

            Assert.Null(contract.Value);
        }

        [Fact]
        public void Ctor_WithName()
        {
            var contract = new NameContract("name");

            Assert.Equal("name", contract.Value);
        }
    }
}
