using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nVentive.Umbrella.Events;
using Xunit;
using nVentive.Umbrella.Extensions;

namespace nVentive.Umbrella.Tests.Events
{
    public class ObservableExtensionsFixture
    {
        private IObservable observable = new Observable();

        [Fact]
        public void Observe()
        {
            observable.Observe((s, a) => {});

            Assert.Equal(1, observable.Observers.Count);
        }

        [Fact]
        public void Raise()
        {
            object sender = new object();
            EventArgs args = new EventArgs();

            object actualSender = null;
            EventArgs actualArgs = null;

            observable.Observe((s, a) => { actualSender = s; actualArgs = a; });
            
            observable.Raise(sender, args);

            Assert.Same(sender, actualSender);
            Assert.Same(args, actualArgs);
        }
    }
}
