using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using nVentive.Umbrella.Extensions;

namespace nVentive.Umbrella.Tests.Validation
{
	public class ValidationExtensionsFixture
	{
		[Fact]
		public void Object_NotNull()
		{
			object o = null;
			var ex = Assert.Throws<ArgumentNullException>(() => o.Validation().NotNull("o"));
			Assert.Equal("o", ex.ParamName);

			o = "hello world";
			Assert.DoesNotThrow(() => o.Validation().NotNull("o"));
		}

		public void String_NotNullOrEmpty()
		{
			string s = null;
			var ex = Assert.Throws<ArgumentNullException>(() => s.Validation().NotNullOrEmpty("null"));
			Assert.Equal("null", ex.ParamName);

			s = string.Empty;
			ex = Assert.Throws<ArgumentNullException>(() => s.Validation().NotNullOrEmpty("empty"));
			Assert.Equal("empty", ex.ParamName);

			s = "hello world";
			var s2 = s.Validation().NotNullOrEmpty("s");
			Assert.Same(s, s2);
		}
	}
}
