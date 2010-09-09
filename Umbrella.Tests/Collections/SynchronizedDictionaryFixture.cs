using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using nVentive.Umbrella.Collections;
using nVentive.Umbrella.Extensions;

namespace nVentive.Umbrella.Tests.Collections
{
    public class SynchronizedDictionaryFixture
    {
        [Fact]
        public void Add()
        {
            var dictionary = new SynchronizedDictionary<string, string>();

            dictionary.Add("1", "11");

            Assert.Contains("11", dictionary["1"]);
        }

        [Fact]
        public void LockedRead()
        {
            var values = Enumerable.Range(1, 10);
            var dictionary = new SynchronizedDictionary<int, int>(values.ToDictionary(a => a * 2));

            Assert.Equal(5, dictionary.Lock.Read(d => d[10]));
            Assert.Equal(-1, dictionary.Lock.Read(d => d.GetValueOrDefault(15, -1)));
        }

        [Fact]
        public void LockedWrite()
        {
            var values = Enumerable.Range(1, 10);
            var dictionary = new SynchronizedDictionary<int, int>(values.ToDictionary(a => a * 2));

            Assert.Equal(15, dictionary.Lock.Write(d => d[15] = 15));
            Assert.Equal(15, dictionary.Lock.Read(d => d.GetValueOrDefault(15)));
        }

        [Fact]
        public void LockedReadWrite()
        {
            var values = Enumerable.Range(1, 10);
            var dictionary = new SynchronizedDictionary<int, int>(values.ToDictionary(a => a * 2));

            int readValue = -1;
            dictionary.Lock.Write(
                d => (readValue = d.GetValueOrDefault(15, -1)) != -1,
                d => readValue = d[15] = 15
            );

            Assert.Equal(15, readValue);

            readValue = -1;
            dictionary.Lock.Write(
                d => (readValue = d.GetValueOrDefault(15, -1)) != -1,
                d => d[15] = 16
            );

            Assert.Equal(15, readValue);
        }

        [Fact]
        public void RemoveKeys()
        {
            var dictionary = new SynchronizedDictionary<string, string>();

            var collection = new[] {
                new KeyValuePair<string, string>("22", "33"),
                new KeyValuePair<string, string>("44", "55"),
                new KeyValuePair<string, string>("66", "77"),
            };

            dictionary.AddRange(collection);

            Assert.Equal(dictionary.Count, collection.Count());

            dictionary.RemoveKeys(collection.Select(t => t.Key));

            Assert.Equal(0, dictionary.Count());
        }

#if !SILVERLIGHT
        [Fact]
        public void Serialization()
        {
            var dictionary = new SynchronizedDictionary<string, string>();

            var collection = new[] {
                new KeyValuePair<string, string>("22", "33"),
                new KeyValuePair<string, string>("44", "55"),
                new KeyValuePair<string, string>("66", "77"),
            };

            dictionary.AddRange(collection);

            var serialized = dictionary.Serialization().Binary();

            Assert.True(dictionary.ToList().Equality().Equal(serialized)); 
        }
#endif
    }
}
