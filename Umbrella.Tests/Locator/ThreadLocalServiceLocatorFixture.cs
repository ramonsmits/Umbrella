using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Xunit;
using nVentive.Umbrella;
using nVentive.Umbrella.Factories;
using nVentive.Umbrella.Extensions;
using nVentive.Umbrella.Conversion;

namespace nVentive.Umbrella.Tests.Locator
{
    public class ThreadLocalServiceLocatorFixture
    {
        [Fact]
        public void MultithreadConversionTest()
        {
            // This test may not fail every time if there is a threading problem.
            int[] items = new int[300];
            int nbItem = items.Length;

            // Creating an input list to convert
            for (int i = 0; i < nbItem; i++)
                items[i] = i;

            string[] converted = new string[items.Count()];

            // Creating 1 thread per conversion
            Thread[] threads = new Thread[items.Count()];
            for (int i = 0; i < nbItem; i++)
            {
                threads[i] = new Thread(x => converted[(int) x] = x.Conversion().To<string>());
                threads[i].Name = "Conversionon on Thread number " + i;
            }

            // Starting all threads
            for (int j = 0; j < nbItem; j++)
                threads[j].Start(items[j]);

            // Waiting for all thread to complete
            for (int j = 0; j < nbItem; j++)
                threads[j].Join();

            // Validating results
            for (int j = 0; j < nbItem; j++)
                Assert.Equal(items[j].ToString(), converted[j]);
        }
    }
}