using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using nVentive.Umbrella.Extensions;

namespace nVentive.Umbrella.Tests.Extensions
{
    public class FuncMemoizeExtensionsFixture
    {       
        [Fact]
        public void ParameterLessMemoize()
        {
            int originalValue = 41;
            int counter = 0;

            Func<int> v = () =>
            {
                counter++;
                return originalValue + 1;
            };

            v = v.AsMemoized();

            // Test to see if the value is correct
            Assert.Equal(originalValue + 1, v());

            // We should have evaluated the method once
            Assert.Equal(1, counter);

            // Test again, the value should not have changed
            Assert.Equal(originalValue + 1, v());

            // We should not have evaluated the method an other time
            Assert.Equal(1, counter);
        }

        [Fact]
        public void SingleParameterMemoize()
        {
            int originalValue = 41;
            int counter = 0;

            Func<int, int> v = (a) =>
            {
                counter++;
                return originalValue + a;
            };

            v = v.AsMemoized();

            // Test to see if the value is correct
            Assert.Equal(originalValue + 1, v(1));
            Assert.Equal(1, counter);

            // Test again, the value should not have changed
            Assert.Equal(originalValue + 1, v(1));
            Assert.Equal(1, counter);

            // Test again, the value should have once
            Assert.Equal(originalValue + 2, v(2));
            Assert.Equal(2, counter);

            // For the same value, the method should not have been called
            Assert.Equal(originalValue + 2, v(2));
            Assert.Equal(2, counter);
        }

        [Fact]
        public void SingleParameterLockedMemoize()
        {
            int originalValue = 41;
            int counter = 0;

            Func<int, int> v = (a) =>
            {
                counter++;
                return originalValue + a;
            };

            v = v.AsLockedMemoized();

            // Test to see if the value is correct
            Assert.Equal(originalValue + 1, v(1));
            Assert.Equal(1, counter);

            // Test again, the value should not have changed
            Assert.Equal(originalValue + 1, v(1));
            Assert.Equal(1, counter);

            // Test again, the value should have once
            Assert.Equal(originalValue + 2, v(2));
            Assert.Equal(2, counter);

            // For the same value, the method should not have been called
            Assert.Equal(originalValue + 2, v(2));
            Assert.Equal(2, counter);
        }


        [Fact]
        public void TwoParameterMemoize()
        {
            int originalValue = 41;
            int counter = 0;

            Func<int, int, int> v = (a,b) =>
            {
                counter++;
                return originalValue + a + b;
            };

            v = v.AsLockedMemoized();

            // Test to see if the value is correct
            Assert.Equal(originalValue + 2, v(1, 1));
            Assert.Equal(1, counter);

            // Test again, the value should not have changed
            Assert.Equal(originalValue + 2, v(1, 1));
            Assert.Equal(1, counter);

            // Test again, the value should have once
            Assert.Equal(originalValue + 3, v(1, 2));
            Assert.Equal(2, counter);

            // For the same value, the method should not have been called
            Assert.Equal(originalValue + 3, v(1, 2));
            Assert.Equal(2, counter);
 
            // For the same value, the method should not have been called
            Assert.Equal(originalValue + 4, v(2, 2));
            Assert.Equal(3, counter);
       }
    }
}
