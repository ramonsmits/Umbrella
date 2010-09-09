using System;
using nVentive.Umbrella.Extensions;
using Xunit;

namespace nVentive.Umbrella.Tests.Validation
{
	public class StringValidationExtensionsFixture
	{
#if !SILVERLIGHT
		[Fact]
		public void String_NotNullOrEmpty_WithNull()
		{
			string value = null;

			var ex = Assert.Throws<ArgumentNullException>(() => value.Validation().NotNullOrEmpty("value"));
			Assert.Equal("value", ex.ParamName);
		}

		[Fact]
		public void String_NotNullOrEmpty_WithEmpty()
		{
			string value = string.Empty;

			var ex = Assert.Throws<ArgumentNullException>(() => value.Validation().NotNullOrEmpty("value"));
			Assert.Equal("value", ex.ParamName);
		}
#endif

		[Fact]
		public void String_NotNullOrEmpty_WithValue()
		{
			string value = "Hello World";

			Assert.DoesNotThrow(() => value.Validation().NotNullOrEmpty("value"));
		}

		[Fact]
		public void String_NotNullOrEmpty_ReturnsSame()
		{
			string value = "Hello World";
			var ret = value.Validation().NotNullOrEmpty("value");
			Assert.Same(value, ret);
		}
	}
}
