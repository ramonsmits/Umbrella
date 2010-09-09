using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using nVentive.Umbrella.Extensions;
using nVentive.Umbrella.Values;
using System.ComponentModel;

namespace nVentive.Umbrella.Tests.Values
{
    public class ReflectionValueFixture
    {
        [Fact]
        public void Value()
        {
            Foo foo = new Foo();
            IValue<int> value = new ReflectionValue<int>(foo, "Age");

            Assert.True(foo.AgeChangedObserved);

            value.Set(10);

            Assert.Equal(10, foo.Age);

            bool changed = false;
            value.Observe((s, a) => changed = true);

            foo.Age = 20;

            Assert.True(changed);

            value.Extensions().Dispose();

            Assert.False(foo.AgeChangedObserved);
        }

        [Fact]
        public void NotifyValue()
        {
            NotifyFoo foo = new NotifyFoo();
            IValue<int> value = new ReflectionValue<int>(foo, "Age");

            Assert.True(foo.PropertyChangedObserved);

            value.Set(10);

            Assert.Equal(10, foo.Age);

            bool changed = false;

            value.Observe((s, a) => changed = true);

            foo.Age = 20;

            Assert.True(changed);

            value.Extensions().Dispose();

            Assert.False(foo.PropertyChangedObserved);
        }

        public class Foo
        {
            private int age;

            public int Age
            {
                get { return age; }
                set
                {
                    age = value;

                    if (AgeChanged != null)
                    {
                        AgeChanged(this, EventArgs.Empty);
                    }
                }
            }

            public event EventHandler<EventArgs> AgeChanged;

            public bool AgeChangedObserved
            {
                get { return AgeChanged != null; }
            }
        }

        public class NotifyFoo : INotifyPropertyChanged
        {
            private int age;

            public int Age
            {
                get { return age; }
                set
                {
                    age = value;

                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("Age"));
                    }
                }
            }

            public bool PropertyChangedObserved
            {
                get { return PropertyChanged != null; }
            }

            #region INotifyPropertyChanged Members

            public event PropertyChangedEventHandler PropertyChanged;

            #endregion
        }

    }
}
