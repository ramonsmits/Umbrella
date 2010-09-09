using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using nVentive.Umbrella.Security;
using System.Threading;
using System.Security.Principal;

namespace nVentive.Framework.Tests.Security
{
    public class ThreadPrincipalSourceFixture
    {
        [Fact]
        public void Get()
        {
            Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity("Identity"), new string[0]);
            var source = new ThreadPrincipalSource();

            Assert.Same(Thread.CurrentPrincipal, source.Value);
        }

        [Fact]
        public void Set()
        {
            var source = new ThreadPrincipalSource();
            source.Value = new GenericPrincipal(new GenericIdentity("Identity"), new string[0]);

            Assert.Same(source.Value, Thread.CurrentPrincipal);
        }
    }
}
