using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using nVentive.Umbrella.Extensions;
using nVentive.Umbrella.Contracts;

namespace nVentive.Umbrella.Tests.Contracts
{
    public class ContractExtensionsFixture
    {
        private IContract nameContract = new NameContract();
        private IContract typeContract = new TypeContract(typeof(int));

        [Fact]
        public void Add()
        {
            Assert.Same(nameContract, ((IContract)null).Add(nameContract));
            Assert.Same(nameContract, nameContract.Add(null));

            IContract compositeContract = nameContract.Add(typeContract);

            Assert.IsType<CompositeContract>(compositeContract);
        }

        [Fact]
        public void Find()
        {
            IContract compositeContract = nameContract.Add(typeContract);

            Assert.Null(nameContract.Find<TypeContract>());
            
            Assert.Same(nameContract, nameContract.Find<NameContract>());
            Assert.Same(nameContract, compositeContract.Find<NameContract>());
            Assert.Same(typeContract, compositeContract.Find<TypeContract>());
        }

        [Fact]
        public void Get()
        {
            IContract compositeContract = nameContract.Add(typeContract);

            Assert.Throws<NotFoundException>(() => nameContract.Get<TypeContract>());
            
            Assert.Same(nameContract, nameContract.Get<NameContract>());
            Assert.Same(nameContract, compositeContract.Get<NameContract>());
            Assert.Same(typeContract, compositeContract.Get<TypeContract>());
        }

        [Fact]
        public void GetOrDefault_Found()
        {
            Type type = typeContract.GetValueOrDefault<TypeContract, Type>();

            Assert.Equal(typeof(int), type);
        }

        [Fact]
        public void GetOrDefault_NotFound()
        {
            Assert.Null(nameContract.GetValueOrDefault<TypeContract, Type>());
        }
    }
}
