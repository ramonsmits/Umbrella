using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using System.Text.RegularExpressions;
using Umbrella.Extensions;

namespace nVentive.Umbrella.Tests.RegularExpressions
{
    public class MatchExtensionsFixture
    {
        [Fact]
        public void SimpleMultiMatch()
        {
            var q = from m in Regex.Match("cdef abc test abc dummy abc foo", "(?<v>abc)").AsEnumerable()
                    select m.Groups["v"].Value;

            Assert.Equal(3, q.Count());
            Assert.Equal(3, q.Count(v => v == "abc"));
        }
    }
}
