using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using nVentive.Umbrella.Extensions;
using System.Reflection;
using nVentive.Umbrella.Reflection;
using nVentive.Umbrella.Sources;
using System.Threading;
using System.ComponentModel;
using nVentive.Umbrella.Events;
using nVentive.Umbrella.Extensions.ValueType;

namespace nVentive.Umbrella.Tests
{
    public class QuickStartFixture
    {
        [Fact]
        public void String_HasValue()
        {
            string s = "abc";

            //Assert.True(!string.IsNullOrEmpty(s));

            Assert.True(s.HasValue());
        }

        [Fact]
        public void String_HasValue_With_Null()
        {
            string s = null;

            Assert.False(s.HasValue());
        }

        [Fact]
        public void Collection_AddRange()
        {
            int[] valuesToAdd = new int[] { 1, 2, 3 };

            ICollection<int> items = new List<int>();

            //foreach (int value in valuesToAdd)
            //{
            //    items.Add(value);
            //}

            items.AddRange(valuesToAdd);

            Assert.Equal(3, items.Count);
        }

        [Fact]
        public void Collection_RemoveEvenItems()
        {
            List<int> items = new List<int> { 1, 2, 3, 4, 5, 6 };

            //List<int> itemsToRemove = new List<int>();

            //foreach (int item in items)
            //{
            //    if (item % 2 == 0)
            //    {
            //        itemsToRemove.Add(item);
            //    }
            //}

            //foreach (int itemToRemove in itemsToRemove)
            //{
            //    items.Remove(itemToRemove);
            //}

            items.Remove(i => i % 2 == 0);

            Assert.Equal(3, items.Count);
        }

        [Fact]
        public void Collection_ForEach()
        {
            var foos = CreateFooList();

            //foreach (Foo foo in foos)
            //{
            //    foo.Do();
            //}

            foos.ForEach(f => f.Do());

            Assert.True(foos.All(f => f.Done));
        }

        [Fact]
        public void Collection_AddDistinct()
        {
            ICollection<Foo> items = new List<Foo> {
                new Foo { Name = "Foo1" },
                new Foo { Name = "Foo2" },
                new Foo { Name = "Foo3" }};

            IEnumerable<Foo> itemsToAdd = new List<Foo> {
                new Foo { Name = "Foo2" },
                new Foo { Name = "Foo4" },
                new Foo { Name = "Foo5" }};

            //Func<Foo, Foo, bool> predicate = (x, y) => x.Name == y.Name;

            //foreach (Foo itemToAdd in itemsToAdd)
            //{
            //    bool exists = false;

            //    foreach (Foo existingItem in items)
            //    {
            //        //if (existingItem.Name == itemToAdd.Name)
            //        if (predicate(itemToAdd, existingItem))
            //        {
            //            exists = true;
            //            break;
            //        }
            //    }

            //    if (!exists)
            //    {
            //        items.Add(itemToAdd);
            //    }
            //}

            items.AddRangeDistinct(itemsToAdd, (x, y) => x.Name == y.Name);

            Assert.Equal(5, items.Count);
        }

        [Fact]
        public void Dictionary_FindOrCreate()
        {
            IDictionary<int, string> values = new Dictionary<int, string>
                {
                    {1, "1"},
                    {2, "2"}
                };

            int key = 3;

            string value;

            //if (!values.TryGetValue(key, out value))
            //{
            //    value = key.ToString();
            //    values.Add(key, value);
            //}

            value = values.FindOrCreate(key, key.ToString);

            Assert.Equal("3", value);
        }

        [Fact]
        public void Type_Is()
        {
            Type fooType = typeof(Foo);

            Type iFooType = typeof(IFoo);

            //Assert.True(iFooType.IsAssignableFrom(fooType));

            Assert.True(fooType.Is<IFoo>());
        }

        [Fact]
        public void Validation_NotNull()
        {
            Foo foo = new Foo();
            Bar bar = new Bar(foo);

            Assert.NotNull(bar.Foo);
        }

        [Fact]
        public void Validation_Null()
        {
            Assert.Throws<ArgumentNullException>(() => new Bar(null));
        }

        [Fact]
        public void Reflection_GetProperty()
        {
            Foo foo = new Foo { Name = "Foo1" };

            //Type fooType = typeof(Foo);
            //PropertyInfo nameProperty = fooType.GetProperty("Name");

            //string name = (string)nameProperty.GetValue(foo, null);

            string name = foo.Reflection().Get<string>("Name");

            Assert.Equal(name, "Foo1");
        }

        [Fact]
        public void Reflection_GetPropertyPath()
        {
            Bar bar = new Bar(new Foo { Name = "Foo1" });

            //Type barType = typeof(Bar);
            //Type fooType = typeof(Foo);
            //PropertyInfo fooProperty = barType.GetProperty("Foo");
            //PropertyInfo nameProperty = fooType.GetProperty("Name");

            //Foo foo = (Foo)fooProperty.GetValue(bar, null);
            //string name = (string)nameProperty.GetValue(foo, null);

            string name = bar.Reflection().Get<string>("Foo.Name".Split('.'));

            Assert.Equal("Foo1", name);
        }

        [Fact]
        public void LazyLoading()
        {
            Zaz zaz = new Zaz();

            Assert.Null(zaz.RawFoo);
            Assert.NotNull(zaz.Foo);
            Assert.NotNull(zaz.RawFoo);
        }

        [Fact]
        public void ThreadLocal()
        {
            ISource<int> threadLocal = new ThreadLocalSource<int>(1);

            int valueOnOtherThread = 0;

            Thread thread = new Thread(() => valueOnOtherThread = threadLocal.Value);
            thread.Start();
            thread.Join();

            Assert.Equal(1, threadLocal.Value);
            Assert.Equal(0, valueOnOtherThread);
        }

        [Fact]
        public void WeakSource()
        {
            Foo foo = new Foo();

            //WeakReference weakFoo = new WeakReference(foo);

            //Assert.Same(foo, weakFoo.Target);

            //foo = null;
            //GC.Collect();
            //GC.WaitForPendingFinalizers();

            //Assert.Null(weakFoo.Target);


            ISource<Foo> weakFoo = new WeakSource<Foo>(foo);

            Assert.Same(foo, weakFoo.Value);

            foo = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();

            Assert.Null(weakFoo.Value);
        }

        [Fact]
        public void RaiseEvent()
        {
            Publisher publisher = new Publisher();

            publisher.Raise();

            bool wasCalled = false;

            publisher.PublishedEvent += (sender, args) => wasCalled = true;

            publisher.Raise();

            Assert.True(wasCalled);
        }

        [Fact]
        public void NotifyPropertyChanged()
        {
            Publisher publisher = new Publisher();

            string modifiedPropertyName = null;

            publisher.PropertyChanged += (sender, args) => modifiedPropertyName = args.PropertyName;

            publisher.MyProperty = "abc";

            Assert.Equal("MyProperty", modifiedPropertyName);
        }

        [Fact]
        public void DateTime_IsWeekDay()
        {
            DateTime odncOnUmbrellaDate = new DateTime(2008, 11, 5);

            Assert.True(odncOnUmbrellaDate.IsWeekDay());
        }

        [Fact]
        public void DateTime_Unit()
        {
            DateTime nineOClock = new DateTime(2008, 1, 1, 9, 0, 0);
            DateTime tenOClock = new DateTime(2008, 1, 1, 10, 0, 0);

            //Assert.True(
            //    (nineOClock.Year == tenOClock.Year) &&
            //    (nineOClock.Month == tenOClock.Month) &&
            //    (nineOClock.Day == tenOClock.Day));

            Assert.True(nineOClock.Equal(tenOClock, DateTimeUnit.ToDay));
        }

        [Fact]
        public void Key()
        {
            Dictionary<IntStringPair, object> values = new Dictionary<IntStringPair, object>();

            int iKey = 1;
            string sKey = "1";

            object value = values.FindOrCreate(new IntStringPair(iKey, sKey), () => new object());

            object otherValue = values.FindOrCreate(new IntStringPair(iKey, sKey), () => new object());

            //Dictionary<Key, object> values = new Dictionary<Key, object>();

            //int iKey = 1;
            //string sKey = "1";

            //object value = values.FindOrCreate(new Key(iKey, sKey), () => new object());

            //object otherValue = values.FindOrCreate(new Key(iKey, sKey), () => new object());

            Assert.Same(value, otherValue);
        }

        [Fact]
        public void ErrorFreeGetHashCode()
        {
            EqualableFoo foo = new EqualableFoo() { MyInt = 5, MyString = "foo1" };

            Assert.NotEqual(0, foo.GetHashCode());
        }

        [Fact]
        public void ErrorFreeEquals()
        {
            EqualableFoo foo1 = new EqualableFoo() { MyInt = 5, MyString = "foo1" };
            EqualableFoo foo2 = new EqualableFoo() { MyInt = 5, MyString = "foo1" };

            Assert.Equal(foo1, foo2);
        }

        [Fact]
        public void Enum_Add()
        {
            BindingFlags flags = BindingFlags.Public;

            //flags = flags | BindingFlags.NonPublic;

            flags = flags.Add(BindingFlags.NonPublic);

            Assert.Equal(BindingFlags.Public | BindingFlags.NonPublic, flags);
        }

        [Fact]
        public void Enum_Remove()
        {
            BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic;

            //flags = flags & ~BindingFlags.NonPublic;

            flags = flags.Substract(BindingFlags.NonPublic);

            Assert.Equal(BindingFlags.Public, flags);
        }

        [Fact]
        public void Enum_ContainsAll()
        {
            BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic;

            //Assert.True(flags & BindingFlags.Public == BindingFlags.Public);
            //Assert.True(flags & BindingFlags.NonPublic == BindingFlags.NonPublic);
            //Assert.True(flags & (BindingFlags.Public | BindingFlags.NonPublic) == BindingFlags.Public | BindingFlags.NonPublic);

            Assert.True(flags.ContainsAll(BindingFlags.Public));
            Assert.True(flags.ContainsAll(BindingFlags.NonPublic));
            Assert.True(flags.ContainsAll(BindingFlags.Public | BindingFlags.NonPublic));

            Assert.False(flags.ContainsAll(BindingFlags.Public | BindingFlags.Instance));
            Assert.False(flags.ContainsAll(BindingFlags.Instance));
        }

        [Fact]
        public void CanConvertEnumToString()
        {
            Gender myGender = Gender.Male;

            //string genderString = GetStringForGender(myGender);
            string genderString = myGender.Conversion().To<String>();

            Assert.Equal("IsMale", genderString);
        }

        [Fact]
        public void CanConvertStringToEnum()
        {
            string genderString = "IsMale";

            //Gender myGender = GetGenderFromString(genderString);
            Gender myGender = genderString.Conversion().To<Gender>();

            Assert.Equal(Gender.Male, myGender);
        }

        [Fact]
        public void CanConvertStringToInt()
        {
            string myString = "5";

            //int myInt = int.Parse(myString);
            int myInt = myString.Conversion().To<int>();

            Assert.Equal(5, myInt);
        }

        private Gender GetGenderFromString(string genderString)
        {
            switch (genderString)
            {
                case "IsMale": return Gender.Male;
                case "IsFemale": return Gender.Female;
            }
            throw new InvalidProgramException();
        }

        public string GetStringForGender(Gender gender)
        {
            switch (gender)
            {
                case Gender.Male: return "IsMale";
                case Gender.Female: return "IsFemale";
            }
            throw new InvalidOperationException();
        }

        public enum Gender
        {
            [Description("IsMale")]
            Male,
            [Description("IsFemale")]
            Female
        }

        private IEnumerable<Foo> CreateFooList()
        {
            return new List<Foo> {
                new Foo { Name = "Foo1" },
                new Foo { Name = "Foo2" },
                new Foo { Name = "Foo3" }};
        }

        private interface IFoo
        {
            void Do();
        }

        private class Foo : IFoo
        {
            public string Name { get; set; }

            public bool Done { get; set; }

            public void Do()
            {
                Done = true;
            }

            protected T Return<T>(T instance)
            {
                return instance;
            }
        }

        private class Bar
        {
            public Bar(Foo foo)
            {
                //if (foo == null)
                //{
                //    throw new ArgumentNullException("foo");
                //}
                //else
                //{
                //    Foo = foo;
                //}

                Foo = foo.Validation().NotNull("foo");
            }

            public Foo Foo { get; private set; }
        }

        private class Zaz
        {
            //private Foo foo;

            //public Foo Foo
            //{
            //    get
            //    {
            //        if (foo == null)
            //        {
            //            foo = new Foo();
            //        }

            //        return foo;
            //    }
            //}

            //public Foo RawFoo
            //{
            //    get { return foo; }
            //}
            private ILazySource<Foo> foo = LazySource.New<Foo>();

            public Foo Foo
            {
                get { return foo.Value; }
            }

            public Foo RawFoo
            {
                get { return foo.IsLoaded ? foo.Value : null; }
            }
        }

        private class Publisher : INotifyPropertyChanged
        {
            private string myProperty;

            public event EventHandler<EventArgs> PublishedEvent;

            public void Raise()
            {
                PublishedEvent.Raise();
            }

            public event PropertyChangedEventHandler PropertyChanged;

            public string MyProperty
            {
                get { return myProperty; }
                set
                {
                    myProperty = value;

                    //if (PropertyChanged != null)
                    //{
                    //    PropertyChanged(this, new PropertyChangedEventArgs("NotMiyProperty"));
                    //}

                    this.Notify(PropertyChanged, x => x.MyProperty);
                }
            }
        }

        private class IntStringPair
        {
            public IntStringPair(int i, string s)
            {
                I = i;
                S = s;
            }

            public int I { get; private set; }
            public string S { get; private set; }

            public override int GetHashCode()
            {
                return I.GetHashCode() ^
                    S.GetHashCode();
            }

            public override bool Equals(object obj)
            {
                IntStringPair other = obj as IntStringPair;

                if (other == null)
                {
                    return false;
                }

                return Equals(I, other.I) &&
                    Equals(S, other.S);
            }
        }

        public class EqualableFoo
        {
            private static readonly Func<EqualableFoo, IEnumerable<object>> Fields = item => new object[] { item.MyInt, item.MyString, item.MyByte };

            public string MyString { get; set; }
            public int MyInt { get; set; }
            public byte MyByte { get; set; }


            public override int GetHashCode()
            {
                //var hashCode = MyInt.GetHashCode();

                //if (MyString != null)
                //{
                //    hashCode ^= MyString.GetHashCode();
                //}

                //return hashCode;

                //return this.Equality().GetHashCode(f => new object[] { f.MyInt, f.MyString });
                return this.Equality().GetHashCode(Fields);
            }

            public override bool Equals(object obj)
            {
                //Foo other = obj as Foo;
                //if (other != null)
                //{
                //    if (Equals(other.MyInt, this.MyInt) &&
                //        Equals(other.MyString, this.MyString))
                //    {
                //        return true;
                //    }
                //}
                //return false;

                //return this.Equality().Equal(obj, f => new object[] { f.MyInt, f.MyString });
                return this.Equality().Equal(obj, Fields);
            }
        }
    }
}
