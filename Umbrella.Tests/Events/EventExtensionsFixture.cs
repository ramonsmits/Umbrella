using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using nVentive.Umbrella.Extensions;
using nVentive.Umbrella.Events;
using System.ComponentModel;

namespace nVentive.Umbrella.Tests.Events
{
    public class EventExtensionsFixture
    {
        [Fact]
        public void Raise()
        {
            object sender = new object();
            EventArgs args = new EventArgs();

            object actualSender = null;
            EventArgs actualArgs = null;

            EventHandler handler = (s, a) => { actualSender = s; actualArgs = a; };

            handler.Raise();

            Assert.Null(actualSender);
            Assert.Equal(EventArgs.Empty, actualArgs);

            handler.Raise(sender, args);

            Assert.Same(sender, actualSender);
            Assert.Same(args, actualArgs);
        }

        [Fact]
        public void Raise_Generic()
        {
            object sender = new object();
            EventArgs args = new EventArgs();

            object actualSender = null;
            EventArgs actualArgs = null;

            EventHandler<EventArgs> handler = (s, a) => { actualSender = s; actualArgs = a; };

            handler.Raise();

            Assert.Null(actualSender);
            Assert.Null(actualArgs);

            handler.Raise(sender, args);

            Assert.Same(sender, actualSender);
            Assert.Same(args, actualArgs);
        }

        [Fact]
        public void ToMessage()
        {
            object sender = new object();
            EventArgs args = new EventArgs();

            object actualSender = null;
            EventArgs actualArgs = null;

            EventHandler<EventArgs> handler = (s, a) => { actualSender = s; actualArgs = a; };

            var message = handler.ToMessage();

            message.Send(new EventMessage<object, EventArgs>());

            handler.Raise(sender, args);

            Assert.Same(sender, actualSender);
            Assert.Same(args, actualArgs);
        }

        [Fact]
        public void Notify()
        {
            Foo foo = new Foo();
            string propertyChangedName = null;
            foo.PropertyChanged += (sender, args) => propertyChangedName = args.PropertyName;

            foo.Value = 2;

            Assert.Equal("Value", propertyChangedName);
        }

        private class Foo : INotifyPropertyChanged
        {
            private int value;

            #region INotifyPropertyChanged Members

            public event PropertyChangedEventHandler PropertyChanged;

            #endregion

            public int Value
            {
                get { return value; }
                set
                {
                    this.value = value;
                    this.Notify(PropertyChanged, item => item.Value);
                }
            } 
        }

    }
}
