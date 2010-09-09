using System;
using nVentive.Umbrella.Extensions;
using Xunit;

namespace nVentive.Umbrella.Tests.Binding
{
	public class CurryExtensionsFixture
	{
		[Fact]
		public void Curry_With_One_Param()
		{
			Func<int, int> echo = (i) => i;

			var always10 = echo.Curry(10);
			Assert.Equal(10, always10());
		}

		[Fact]
		public void Curry_First_With_Two_Params()
		{
			Func<double, double, double> power = Math.Pow;

			var twoToTheN = power.CurryFirst(2.0);
			Assert.Equal(1024.0, twoToTheN(10.0));
		}

		[Fact]
		public void Curry_Last_With_Two_Params()
		{
			Func<double, double, double> power = Math.Pow;

			var square = power.CurryLast(2.0);
			Assert.Equal(4, square(2));
			Assert.Equal(16, square(square(2)));
		}

		[Fact]
		public void Curry_Chaining()
		{
			Func<int, int, int, int, long> func = (a, b, c, d) => a + b + c + d;

			var chain = func.CurryFirst(1).CurryFirst(2).CurryFirst(3).Curry(4);
			Assert.Equal(func(1, 2, 3, 4), chain());
		}
	}
}
