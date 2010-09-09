using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using nVentive.Umbrella.Components;
using nVentive.Umbrella.Locator;
using nVentive.Umbrella.Extensions;

namespace nVentive.Umbrella.Tests.Components
{
    public class ComponentFixture
    {
        [Fact]
        public void Ctor()
        {
            var component = new FooComponent();
        }

        [Fact]
        public void OverridesEqual()
        {
            var foo1 = new FooComponent { I = 1 };
            var foo2 = new FooComponent { I = 1 };

            Assert.Equal(foo1, foo2);
        }

        [Fact]
        public void OverridesGetHashCode()
        {
            var foo = new FooComponent { I = 1 };

            int expectedHash = EqualityExtensions.Equality<Component>(foo).GetHashCode(new object[] { foo.I });

            Assert.Equal(expectedHash, foo.GetHashCode());
        }

        [Fact]
        public void ServiceLocator_Get()
        {
            var component = new FooComponent();

            Assert.Same(ServiceLocator.Instance, component.ServiceLocator);
        }

        private class FooComponent : Component
        {
            public int I
            {
                get;
                set;
            }

            protected override IEnumerable<object> Fields
            {
                get
                {
                    yield return I;
                }
            }
        }
    }
}
