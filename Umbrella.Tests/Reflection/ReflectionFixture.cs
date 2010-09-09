using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xunit;

using nVentive.Umbrella.Extensions;
using nVentive.Umbrella.Reflection;
using nVentive.Umbrella.Decorator;

namespace nVentive.Umbrella.Tests.Reflection
{
    public class ReflectionFixture
    {
        [Fact]
        public void Event()
        {
            ObservableFoo foo = new ObservableFoo();

            foo.Changed += (s, a) => { };

            object o = foo.Reflection().FindDescriptor("Changed");
        }

        [Fact]
        public void Instance()
        {
            Foo foo = new Foo();

            var fooReflection = foo.Reflection();

#if !SILVERLIGHT
            // Silverlight does not allow access to private members through reflection

            Assert.Equal(foo.I, fooReflection.Get("i"));

            fooReflection.Set("i", 2);

            Assert.Equal(2, foo.I);

            Assert.Equal(2, fooReflection.Get("I"));
#endif

            fooReflection.Set("I", 3);

            Assert.Equal(3, foo.I);

            Assert.Equal(3, fooReflection.Get("GetI"));

            fooReflection.Set("SetI", 4);

            Assert.Equal(4, foo.I);
        }

        [Fact]
        public void Static()
        {
            Type fooType = typeof(StaticFoo);

            var fooReflection = fooType.Reflection();

#if !SILVERLIGHT
         Assert.Equal(StaticFoo.I, fooReflection.Get("i"));

            fooReflection.Set("i", 2);

            Assert.Equal(2, StaticFoo.I);

            Assert.Equal(2, fooReflection.Get("I"));
#endif

            fooReflection.Set("I", 3);

            Assert.Equal(3, StaticFoo.I);

            Assert.Equal(3, fooReflection.Get("GetI"));

            fooReflection.Set("SetI", 4);

            Assert.Equal(4, StaticFoo.I);
        }

        [Fact]
        public void Path()
        {
            Type type = typeof(Bar0);

            string path = "Bar1.bar2.Bar3.GetI";

            IEnumerable<IValueMemberDescriptor> items = type.Reflection().GetValueDescriptors(path.Split('.'));

            Assert.Equal(4, items.Count());
            Assert.Equal(typeof(Bar0.Bar1), items.ElementAt(0).Type);
            Assert.Equal(typeof(Bar2), items.ElementAt(1).Type);
            Assert.Equal(typeof(Bar3), items.ElementAt(2).Type);
            Assert.Equal(typeof(int), items.ElementAt(3).Type);

            Assert.Equal(2, type.Reflection().Get<int>(path.Split('.')));

            type.Reflection().Set("Bar1.bar2.Bar3.SetI".Split('.'), 4);

            Assert.Equal(4, type.Reflection().Get<int>(path.Split('.')));
        }

        public class StaticFoo
        {
            private static int i = 1;

            public static int I
            {
                get { return i; }
                set { i = value; }
            }

            public static int GetI()
            {
                return i;
            }

            public static void SetI(int value)
            {
                i = value;
            }
        }

        public class Foo
        {
            private int i = 1;

            public int I
            {
                get { return i; }
                set { i = value; }
            }

            public int GetI()
            {
                return i;
            }

            public void SetI(int value)
            {
                i = value;
            }
        }

        public class Bar0
        {
            public class Bar1
            {
                public static Bar2 bar2 = new Bar2();
            }
        }

        public class Bar2
        {
            private Bar3 bar3 = new Bar3();

            public Bar3 Bar3
            {
                get { return bar3; }
            }
        }

        public class Bar3
        {
            public int I = 2;

            public int GetI()
            {
                return I;
            }

            public void SetI(int value)
            {
                I = value;
            }
        }

        public class Foo1
        {
            private class Foo2
            {
                public static int I = 4;
            }
        }

        public class ObservableFoo
        {
            public event EventHandler<EventArgs> Changed;
        }

        public class ReflectionValueFoo
        {
            public string Text { get; set; }
            public EventHandler<EventArgs> TextChanged;
        }
    }
}
