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
    public class MethodInfoExtensionsFixture
    {
        [Fact]
        public void SimpleVoidCallNoParam()
        {
            Action<Func<object, object[], object>> action = 
                method =>
                {
                    MethodContainer mc = new MethodContainer();

                    var ret = method(mc, new object[0]);

                    Assert.False(method.Method.DeclaringType.Is<MethodBase>());
                    Assert.Equal(mc.callCounter, 1);
                    Assert.Null(ret);
                };

            var methodInfo = new MethodContainer().Reflection().GetDescriptor(c => c.SimpleVoidCallNoParam()) as IMethodDescriptor;

            action(methodInfo.ToCompiledMethodInvoke());
            action(methodInfo.ToCompiledMethodInvoke(false));
        }

        [Fact]
        public void SimpleCallVoidIntParam()
        {
            Action<Func<object, object[], object>> action =
                method =>
                {
                    MethodContainer mc = new MethodContainer();

                    var ret = method(mc, new object[] { 42 });

                    Assert.False(method.Method.DeclaringType.Is<MethodBase>());
                    Assert.Equal(mc.callCounter, 1);
                    Assert.Null(ret);
                };

            var methodInfo = new MethodContainer().Reflection().GetDescriptor(c => c.SimpleCallVoidIntParam(0)) as IMethodDescriptor;

            action(methodInfo.ToCompiledMethodInvoke());
            action(methodInfo.ToCompiledMethodInvoke(false));
        }

        [Fact]
        public void SimpleCallIntIntParam()
        {
            Action<Func<object, object[], object>> action =
                method =>
                {
                    MethodContainer mc = new MethodContainer();
                    var ret = method(mc, new object[] { 42 });

                    Assert.False(method.Method.DeclaringType.Is<MethodBase>());
                    Assert.Equal(ret, 42);
                    Assert.Equal(mc.callCounter, 1);
                };

            var methodInfo = new MethodContainer().Reflection().GetDescriptor(c => c.SimpleCallIntIntParam(0)) as IMethodDescriptor;

            action(methodInfo.ToCompiledMethodInvoke());
            action(methodInfo.ToCompiledMethodInvoke(false));
        }

        [Fact]
        public void SimpleCallStringStringParam()
        {
            Action<Func<object, object[], object>> action =
                method =>
                {
                    MethodContainer mc = new MethodContainer();
                    var ret = method(mc, new object[] { "test" });

                    Assert.False(method.Method.DeclaringType.Is<MethodBase>());
                    Assert.Equal("test", ret);
                    Assert.Equal(mc.callCounter, 1);
                };

            var methodInfo = new MethodContainer().Reflection().GetDescriptor(c => c.SimpleCallStringStringParam("")) as IMethodDescriptor;

            action(methodInfo.ToCompiledMethodInvoke());
            action(methodInfo.ToCompiledMethodInvoke(false));
        }

        [Fact]
        public void SimpleCallStringStringIntParam()
        {
            Action<Func<object, object[], object>> action =
                method =>
                {
                    MethodContainer mc = new MethodContainer();
                    var ret = method(mc, new object[] { "test", 42 });

                    Assert.False(method.Method.DeclaringType.Is<MethodBase>());
                    Assert.Equal("test42", ret);
                    Assert.Equal(mc.callCounter, 1);
                };

            var methodInfo = new MethodContainer().Reflection().GetDescriptor(c => c.SimpleCallStringStringIntParam("", 0)) as IMethodDescriptor;

            action(methodInfo.ToCompiledMethodInvoke());
            action(methodInfo.ToCompiledMethodInvoke(false));
        }

        [Fact]
        public void SimpleCallStringStringOutIntParam()
        {
            Action<Func<object, object[], object>> action =
                method =>
                {
                    MethodContainer mc = new MethodContainer();

                    var array = new object[] { "test", 0 };
                    var ret = method(mc, array);

                    Assert.True(method.Method.DeclaringType.Is<MethodBase>());
                    Assert.Equal("test42", ret);
                    Assert.Equal(42, array[1]);
                    Assert.Equal(mc.callCounter, 1);
                };

            int outValue = 0;
            var methodInfo = new MethodContainer().Reflection().GetDescriptor(c => c.SimpleCallStringStringOutIntParam("", out outValue)) as IMethodDescriptor;

            action(methodInfo.ToCompiledMethodInvoke());
            action(methodInfo.ToCompiledMethodInvoke(false));
        }

        [Fact]
        public void SimpleCallRefIntParam()
        {
            Action<Func<object, object[], object>> action =
                method =>
                {
                    MethodContainer mc = new MethodContainer();

                    var array = new object[] { 21 };
                    var ret = method(mc, array);

                    Assert.True(method.Method.DeclaringType.Is<MethodBase>());
                    Assert.Equal(42, ret);
                    Assert.Equal(42, array[0]);
                    Assert.Equal(mc.callCounter, 1);
                };

            int outValue = 0;
            var methodInfo = new MethodContainer().Reflection().GetDescriptor(c => c.SimpleCallRefIntParam(ref outValue)) as IMethodDescriptor;

            action(methodInfo.ToCompiledMethodInvoke());
            action(methodInfo.ToCompiledMethodInvoke(false));
        }

        [Fact]
        public void SimpleCallStringsParamsParam()
        {
            Action<Func<object, object[], object>> action =
                method =>
                {
                    MethodContainer mc = new MethodContainer();

                    var array = new object[] { new[] { "test1", "test2" } };
                    var ret = method(mc, array);

                    Assert.False(method.Method.DeclaringType.Is<MethodBase>());
                    Assert.Equal("test1,test2", ret);
                    Assert.Equal(mc.callCounter, 1);
                };

            var methodInfo = new MethodContainer().Reflection().GetDescriptor(c => c.SimpleCallStringsParamsParam()) as IMethodDescriptor;

            action(methodInfo.ToCompiledMethodInvoke());
            action(methodInfo.ToCompiledMethodInvoke(false));
        }

        [Fact]
        public void GenericCallIntIntParam()
        {
            Action<Func<object, object[], object>> action =
                method =>
                {
                    MethodContainer<int> mc = new MethodContainer<int>();

                    var ret = method(mc, new object[] { 42 });

                    Assert.False(method.Method.DeclaringType.Is<MethodBase>());
                    Assert.Equal(ret, 42);
                    Assert.Equal(mc.callCounter, 1);
                };

            var methodInfo = new MethodContainer<int>().Reflection().GetDescriptor(c => c.SimpleCallIntIntParam(0)) as IMethodDescriptor;

            action(methodInfo.ToCompiledMethodInvoke());
            action(methodInfo.ToCompiledMethodInvoke(false));
        }

        [Fact]
        public void SimpleStaticCallIntIntParam()
        {
            Action<Func<object, object[], object>> action =
                method =>
                {
                    int originalCount = MethodContainer.staticCallCounter;

                    var ret = method(null, new object[] { 42 });

                    Assert.False(method.Method.DeclaringType.Is<MethodBase>());
                    Assert.Equal(ret, 43);
                    Assert.Equal(originalCount + 1, MethodContainer.staticCallCounter);
                };
                    
            var methodInfo = new MethodContainer().Reflection().GetDescriptor(c => MethodContainer.SimpleStaticCallIntIntParam(0)) as IMethodDescriptor;

            action(methodInfo.ToCompiledMethodInvoke());
            action(methodInfo.ToCompiledMethodInvoke(false));
        }   

        [Fact]
        public void SimpleVirtualBaseCall()
        {
            Action<Func<object, object[], object>> action =
                method =>
                {
                    MethodContainer mc = new MethodContainer();

                    var ret = method(mc, new object[] { 42 });

                    Assert.False(method.Method.DeclaringType.Is<MethodBase>());
                    Assert.Equal(ret, 43);
                    Assert.Equal(mc.callCounter, 1);
                };
                    
            var methodInfo = new MethodContainer().Reflection().GetDescriptor(c => c.SimpleVirtualMethod(0)) as IMethodDescriptor;

            action(methodInfo.ToCompiledMethodInvoke());
            action(methodInfo.ToCompiledMethodInvoke(false));
        }   

        [Fact]
        public void SimpleOverloadedBaseCall()
        {
            Action<Func<object, object[], object>> action =
                method =>
                {
                    MethodContainerParent mc = new MethodContainerParent();


                    var ret = method(mc, new object[] { 42 });

                    Assert.False(method.Method.DeclaringType.Is<MethodBase>());
                    Assert.Equal(ret, 44);
                    Assert.Equal(mc.callCounter, 2);
                };

            var methodInfo = new MethodContainer().Reflection().GetDescriptor(c => c.SimpleVirtualMethod(0)) as IMethodDescriptor;

            action(methodInfo.ToCompiledMethodInvoke());
            action(methodInfo.ToCompiledMethodInvoke(false));
        }       

        [Fact]
        public void SimpleOverloadedSuperCall()
        {
            Action<Func<object, object[], object>> action =
                method =>
                {
                    MethodContainerParent mc = new MethodContainerParent();

                    var ret = method(mc, new object[] { 42 });

                    Assert.False(method.Method.DeclaringType.Is<MethodBase>());
                    Assert.Equal(ret, 44);
                    Assert.Equal(mc.callCounter, 2);
                };

            var methodInfo = new MethodContainer().Reflection().GetDescriptor(c => c.SimpleVirtualMethod(0)) as IMethodDescriptor;

            action(methodInfo.ToCompiledMethodInvoke());
            action(methodInfo.ToCompiledMethodInvoke(false));
        }

        [Fact]
        public void StructTest()
        {
            var methodInfo = new TestStruct().Reflection().GetDescriptor(c => c.TestMethod(0)) as IMethodDescriptor;
            var method = methodInfo.ToCompiledMethodInvoke();

            TestStruct ts = new TestStruct();

            var ret = method(ts, new object[] { 40 });

            Assert.True(method.Method.DeclaringType.Is<MethodBase>());
            Assert.Equal(42, ret);
        }
    }

    struct TestStruct
    {
        public int TestMethod(int value)
        {
            return value+2;
        }
    }

    class MethodContainer<T>
    {
        public int callCounter = 0;

        public T SimpleCallIntIntParam(T a)
        {
            callCounter++;

            return a;
        }
    }

    class MethodContainer
    {
        public int callCounter = 0;

        public static int staticCallCounter = 0;

        public static int SimpleStaticCallIntIntParam(int a)
        {
            staticCallCounter++;

            return a+1;
        }

        public void SimpleVoidCallNoParam()
        {
            callCounter++;
        }

        public void SimpleCallVoidIntParam(int a)
        {
            callCounter++;
        }

        public int SimpleCallIntIntParam(int a)
        {
            callCounter++;

            return a;
        }

        public string SimpleCallStringStringParam(string a)
        {
            callCounter++;

            return a;
        }

        public string SimpleCallStringStringIntParam(string a, int b)
        {
            callCounter++;

            return a + b.ToString();
        }

        public string SimpleCallStringStringOutIntParam(string a, out int b)
        {
            callCounter++;

            b = 42;

            return a + b.ToString();
        }

        public string SimpleCallStringsParamsParam(params string[] test)
        {
            callCounter++;

            return string.Join(",", test);
        }

        public int SimpleCallRefIntParam(ref int b)
        {
            callCounter++;

            b = 42;

            return b;
        }

        public virtual int SimpleVirtualMethod(int a)
        {
            callCounter++;

            return a + 1;
        }
    }

    class MethodContainerParent : MethodContainer
    {
        public override int SimpleVirtualMethod(int a)
        {
            callCounter++;

            return base.SimpleVirtualMethod(a + 1);
        }
    }
}
