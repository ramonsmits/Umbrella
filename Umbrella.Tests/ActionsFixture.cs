using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using nVentive.Umbrella.Events;
using nVentive.Umbrella.Extensions;

namespace nVentive.Umbrella.Tests
{
    public class ActionsFixture
    {
        [Fact]
        public void Null()
        {
            Actions.Null();
        }

        [Fact]
        public void Null_Generic()
        {
            Actions<int>.Null(1);
        }

        [Fact]
        public void Null_Generic_Two_Arguments()
        {
            Actions<int, string>.Null(1, "A");
        }

        [Fact]
        public void Create()
        {
            bool called = false;

            Actions.Create(() => called = true)();

            Assert.True(called);
        }

        [Fact]
        public void Create_Generic()
        {
            int i = 0;

            Actions.Create<int>(value => i = value)(1);

            Assert.Equal(1, i);
        }

        [Fact]
        public void Raise()
        {
            IObservable observable = new Observable();
            
            object sender = new object();
            
            object actualSender = null;

            observable.Observe((s, a) => actualSender = sender);

            Actions.Raise(sender, observable);

            Assert.Same(sender, actualSender);
        }
    }
}
