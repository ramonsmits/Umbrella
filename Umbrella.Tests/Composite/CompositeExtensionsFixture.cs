using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using nVentive.Umbrella.Composite;
using nVentive.Umbrella.Extensions;

namespace nVentive.Umbrella.Tests.Composite
{
    public class CompositeExtensionsFixture
    {
        private CompositeFoo foo;

        public CompositeExtensionsFixture()
        {
            foo = new CompositeFoo { new Foo(), new OtherFoo(), new OtherFoo(), new CompositeFoo { new Foo(), new OtherFoo() } };
        }

        [Fact]
        public void SelectMany()
        {
            IEnumerable<IFoo> items = foo.SelectMany();

            Assert.Equal(5, items.Count());
            Assert.Equal(2, items.OfType<Foo>().Count());
            Assert.Equal(3, items.OfType<OtherFoo>().Count());
        }

        [Fact]
        public void SelectMany_Helper()
        {
            IFoo castedFoo = (IFoo)foo;

            IEnumerable<IFoo> items = CompositeExtensions.SelectMany(castedFoo);

            Assert.Equal(5, items.Count());
            Assert.Equal(2, items.OfType<Foo>().Count());
            Assert.Equal(3, items.OfType<OtherFoo>().Count());

        }
        public interface IFoo
        {
            void Do(int i);
        }

        public class CompositeFoo : Composite<IFoo>, IFoo
        {
            #region IFoo Members

            public void Do(int i)
            {
                Items.ForEach(item => item.Do(i));
            }

            #endregion
        }

        private class Foo : IFoo
        {
            #region IFoo Members

            public void Do(int i)
            {
            }

            #endregion
        }

        public class OtherFoo : IFoo
        {
            #region IFoo Members

            public void Do(int i)
            {
            }

            #endregion
        }
    }
}
