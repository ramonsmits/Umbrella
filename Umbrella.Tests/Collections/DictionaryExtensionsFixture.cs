using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using nVentive.Umbrella.Extensions;

namespace nVentive.Umbrella.Tests.Collections
{
    public class DictionaryExtensionsFixture
    {
        [Fact]
        public void FindOrCreate()
        {
            var values = Enumerable.Range(1, 10);
            var dictionary = values.ToDictionary(a => a * 2);

            var ret = dictionary.FindOrCreate(42, () => 42);
            Assert.Equal(ret, 42);

            ret = dictionary.FindOrCreate(42, () => 21);
            Assert.Equal(ret, 42);
        }

        [Fact]
        public void GetValueOrDefault()
        {
            var values = Enumerable.Range(1, 10);
            var dictionary = values.ToDictionary(a => a * 2);

            var ret = dictionary.GetValueOrDefault(10);
            Assert.Equal(5, ret);

            ret = dictionary.GetValueOrDefault(42);
            Assert.Equal(0, ret);

            ret = dictionary.GetValueOrDefault(42, 21);
            Assert.Equal(21, ret);
        }

        [Fact]
        public void RemoveKeys()
        {
            var values = Enumerable.Range(1, 10);

            var dictionary = values.ToDictionary(a => a * 2);

            var removed = dictionary.RemoveKeys(values.Where(i => (i % 2) == 0));

            Assert.Equal(removed.Count(), 5);
        }

        [Fact]
        public void RemoveKeysNoReturn()
        {
            var values = Enumerable.Range(1, 10);

            var dictionary = values.ToDictionary(a => a * 2);

            dictionary.RemoveKeys(values.Where(i => (i % 2) == 0));

			Assert.Equal(dictionary.Count, 5);
        }    
	}
}
