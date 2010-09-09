// Project: Umbrella.Tests, File: StringExtensionsFixture.cs
// Namespace: nVentive.Umbrella.Tests.Extensions, Class: StringExtensionsFixture
// Path: C:\Projects - CodePlex\umbrella\Main\Src\Umbrella.Tests\Extensions, Author: stephane.lapointe
// Code lines: 47, Size of file: 1.02 KB
// Creation date: 11/11/2008 1:46 PM
// Last modified: 11/11/2008 1:52 PM
// Generated with Commenter

#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using nVentive.Umbrella.Extensions;
#endregion

namespace nVentive.Umbrella.Tests.Extensions
{
    public class StringExtensionsFixture
    {
        [Fact]
        public void IsNullOrEmpty()
        {
            Assert.True(((string)null).IsNullOrEmpty());
            Assert.True("".IsNullOrEmpty());
            Assert.False("A".IsNullOrEmpty());
        }

        [Fact]
        public void HasValue()
        {
            Assert.False(((string)null).HasValue());
            Assert.False("".HasValue());
            Assert.True("A".HasValue());
        }

        [Fact]
        public void IsNumber()
        {
            Assert.True("123".IsNumber());
            Assert.False("1A2".IsNumber());
        }

        [Fact]
        public void IsDigit()
        {
            Assert.True("123".IsDigit());
            Assert.False("1A2".IsDigit());
        }

		[Fact]
		public void Left()
		{
			string testValue = "some text";

			// should raise ArgumentException if negative
			Assert.Throws<ArgumentException>(() => testValue.Left(-1));

			//should return ""
			Assert.Equal(string.Empty, ((string)null).Left(4));

			// should return ""
			Assert.Equal(string.Empty, (testValue).Left(0));

			// should return the first 7 characters
			Assert.Equal("some te", testValue.Left(7));

			// should return the whole value
			Assert.Equal(testValue, testValue.Left(testValue.Length + 1));
		}

		[Fact]
		public void Right()
		{
			string testValue = "some text";

			// should raise ArgumentException if negative
			Assert.Throws<ArgumentException>(() => testValue.Right(-1));

			//should return ""
			Assert.Equal(string.Empty, ((string)null).Right(4));

			// should return ""
			Assert.Equal(string.Empty, (testValue).Right(0));

			// should return the first 7 characters
			Assert.Equal("me text", testValue.Right(7));

			// should return the whole value
			Assert.Equal(testValue, testValue.Right(testValue.Length + 1));
		}

        [Fact]
        public void AppendTest()
        {
            Assert.Equal("BeginEnd", "Begin".Append("End"));
            Assert.Equal("End", ((string)null).Append("End"));
            Assert.Equal("Begin", "Begin".Append(null));
        }

        [Fact]
        public void AppendConditionTest()
        {
            Assert.Equal(@"C:\", @"C:".Append(@"\", s => !s.EndsWith(@"\")));
            Assert.Equal(@"C:\", @"C:\".Append(@"\", s => !s.EndsWith(@"\")));
        }

        [Fact]
        public void AppendIfMissingTest()
        {
            Assert.Equal(@"C:\", @"C:".AppendIfMissing(@"\"));
            Assert.Equal(@"C:\", @"C:\".AppendIfMissing(@"\"));
        }
    }
}
