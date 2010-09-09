using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using nVentive.Umbrella.Extensions;
using System.Linq.Expressions;

namespace nVentive.Umbrella.Tests.Extensions
{
    public class DateTimeExtensionsFixture
    {
        public class Customer
        {
            public string City { get; set; }
        }

        [Fact]
        public void IsWeekDay()
        {
            Assert.True(new DateTime(2008, 2, 1).IsWeekDay());
            Assert.False(new DateTime(2008, 2, 2).IsWeekDay());
        }

        [Fact]
        public void IsWeekEnd()
        {
            Assert.False(new DateTime(2008, 2, 1).IsWeekEnd());
            Assert.True(new DateTime(2008, 2, 2).IsWeekEnd());
        }

        [Fact]
        public void Equal()
        {
            DateTime x = new DateTime(2008, 2, 1);
            DateTime y = new DateTime(2008, 2, 2);

            Assert.True(x.Equal(y, DateTimeUnit.ToMonth));
            Assert.False(x.Equal(y, DateTimeUnit.ToDay));
        }

        [Fact]
        public void Truncate()
        {
            Assert.Equal(new DateTime(2008, 2, 1), new DateTime(2008, 2, 2).Truncate(DateTimeUnit.ToMonth));
        }
    }
}
