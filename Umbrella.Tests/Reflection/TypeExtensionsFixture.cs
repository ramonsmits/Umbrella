using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using nVentive.Umbrella.Extensions;
using System.Reflection;

namespace nVentive.Umbrella.Tests.Reflection
{
    public class TypeExtensionsFixture
    {
        [Fact]
        public void GetMemberInfoExpressionMethod()
        {
            var info = (null as IDisposable).Reflection().GetDescriptor(i => i.Dispose());

            Assert.Equal(info.MemberInfo, typeof(IDisposable).GetMethod("Dispose"));
        }

        [Fact]
        public void GetMemberInfoExpressionProperty()
        {
            var info = GetType().Reflection<Type>().GetDescriptor(i => i.Assembly);

            Assert.Equal(info.MemberInfo, typeof(Type).GetProperty("Assembly"));
        }

        [Fact]
        public void GetMemberInfoExpressionField()
        {
            var info = new Dummy().Reflection().GetDescriptor(i => i.A);

            Assert.Equal(info.MemberInfo, typeof(Dummy).GetField("A"));
        }

        class Dummy
        {
            public int A;
        }
    }

}
