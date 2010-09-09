using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using nVentive.Umbrella.Extensions;

namespace nVentive.Umbrella.Tests.Collections
{
    public class GroupingExtensionsFixture
    {
        [Fact]
        public void ToDictionary()
        {
            string[] words = { "blueberry", "chimpanzee", "abacus", "banana", "apple", "cheese" };

            IEnumerable<IGrouping<char, string>> wordGroups =
                from w in words
                group w by w[0];

            Dictionary<char, IEnumerable<string>> groupedWords = wordGroups.ToGroupedDictionary();

            Assert.Equal(2, groupedWords['a'].Count());
            Assert.Equal(2, groupedWords['b'].Count());
            Assert.Equal(2, groupedWords['c'].Count());

            Assert.True(groupedWords['a'].Contains("abacus"));
            Assert.True(groupedWords['a'].Contains("apple"));
        }
    }
}
