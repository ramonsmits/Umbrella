using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using nVentive.Umbrella.Extensions;
using System.Reflection;
using nVentive.Umbrella.Reflection;

namespace nVentive.Umbrella.Tests.Reflection
{
    public class FieldInfoExtensionsFixture
    {
        [Fact]
        public void NonPublicSetValueType()
        {
            var setter = (typeof(NonPublicClass).Reflection().GetDescriptor("publicField") as IValueMemberDescriptor).ToCompiledSetValue();

            var instance = new NonPublicClass();

            setter(instance, 42);

            Assert.Equal(42, instance.publicField);
        }

        [Fact]
        public void NonPublicSetReferenceType()
        {
            var setter = (typeof(NonPublicClass).Reflection().GetDescriptor("disposableField") as IValueMemberDescriptor).ToCompiledSetValue();

            var instance = new NonPublicClass();

            DateTime? value = null;
            setter(instance, Actions.Create(() => value = DateTime.Now).ToDisposable());

            Assert.NotNull(instance.disposableField);

            instance.disposableField.Dispose();

            Assert.NotNull(value);
        }

        [Fact]
        public void NonPublicSetInvalidReferenceTypeStrict()
        {
            var setter = (typeof(NonPublicClass).Reflection().GetDescriptor("disposableField") as IValueMemberDescriptor).ToCompiledSetValue();

            var instance = new NonPublicClass();

            Assert.Throws<InvalidCastException>(() => setter(instance, 42));
        }

        [Fact]
        public void NonPublicSetInvalidReferenceTypeLoose()
        {
            var setter = (typeof(NonPublicClass).Reflection().GetDescriptor("disposableField") as IValueMemberDescriptor).ToCompiledSetValue(false);

            var instance = new NonPublicClass();

            setter(instance, 42);

            Assert.Throws<EntryPointNotFoundException>(() => instance.disposableField.Dispose());
        }

        [Fact]
        public void PublicSetValueType()
        {
            var setter = (typeof(PublicClass).Reflection().GetDescriptor("publicField") as IValueMemberDescriptor).ToCompiledSetValue();

            var instance = new PublicClass();

            setter(instance, 42);

            Assert.Equal(42, instance.publicField);
        }    

        [Fact]
        public void NonPublicSetPrivateValueType()
        {
            var setter = (typeof(NonPublicClass).Reflection().GetDescriptor("privateField") as IValueMemberDescriptor).ToCompiledSetValue();

            var instance = new NonPublicClass();

            setter(instance, 42);

            Assert.Equal(42, instance.GetPrivateField());
        }

        [Fact]
        public void PublicSetValueTypeInvalidInstanceStrict()
        {
            var setter = (typeof(PublicClass).Reflection().GetDescriptor("publicField") as IValueMemberDescriptor).ToCompiledSetValue();

            var instance = new NonPublicClass();

            Assert.Throws<InvalidCastException>(() => setter(instance, 42));
        }

        [Fact]
        public void NonPublicGetValueType()
        {
            var getter = (typeof(NonPublicClass).Reflection().GetDescriptor("publicField") as IValueMemberDescriptor).ToCompiledGetValue();

            var instance = new NonPublicClass();

            instance.publicField = 42;

            Assert.Equal(42, getter(instance));
        }

        [Fact]
        public void NonPublicGetValueTypeLoose()
        {
            var getter = (typeof(NonPublicClass).Reflection().GetDescriptor("publicField") as IValueMemberDescriptor).ToCompiledGetValue(false);

            var instance = new NonPublicClass();

            instance.publicField = 42;

            Assert.Equal(42, getter(instance));
        }

        [Fact]
        public void NonPublicGetReferenceType()
        {
            var getter = (typeof(NonPublicClass).Reflection().GetDescriptor("disposableField") as IValueMemberDescriptor).ToCompiledGetValue();

            var instance = new NonPublicClass();

            instance.disposableField = Actions.Null.ToDisposable();

            Assert.NotNull(getter(instance));
        }    

        [Fact]
        public void NonPublicGetReferenceTypeLoose()
        {
            var getter = (typeof(NonPublicClass).Reflection().GetDescriptor("disposableField") as IValueMemberDescriptor).ToCompiledGetValue(false);

            var instance = new NonPublicClass();

            instance.disposableField = Actions.Null.ToDisposable();

            Assert.NotNull(getter(instance));
        }  

        [Fact]
        public void PublicGenericGetValueType()
        {
            var getter = (typeof(PublicGenericClass<int>).Reflection().GetDescriptor("publicField") as IValueMemberDescriptor).ToCompiledGetValue();

            var instance = new PublicGenericClass<int>();

            instance.publicField = 42;

            Assert.Equal(42, getter(instance));
        }

        [Fact]
        public void PublicGenericGetReferenceType()
        {
            var getter = (typeof(PublicGenericClass<string>).Reflection().GetDescriptor("publicField") as IValueMemberDescriptor).ToCompiledGetValue();

            var instance = new PublicGenericClass<string>();

            instance.publicField = "test";

            Assert.Equal("test", getter(instance));
        }

        [Fact]
        public void PublicStruct()
        {
            var getter = (typeof(PublicStrict).Reflection().GetDescriptor("field") as IValueMemberDescriptor).ToCompiledGetValue();
            var getter2 = (typeof(PublicStrict).Reflection().GetDescriptor("field2") as IValueMemberDescriptor).ToCompiledGetValue();

            PublicStrict s = new PublicStrict() { field = 42, field2 = 43 };

            Assert.Equal(42, getter(s));
            Assert.Equal(43, getter2(s));
        }
    }

    class NonPublicClass
    {
        public int publicField = 0;
        public IDisposable disposableField = null;
        private int privateField = 0;

        public int GetPrivateField()
        {
            return privateField;
        }
    }

    public class PublicClass
    {
        public int publicField = 0;
    }

    public class PublicGenericClass<T>
    {
        public T publicField = default(T);
    }

    public struct PublicStrict
    {
        public int field;
        public int field2;
    }
}
