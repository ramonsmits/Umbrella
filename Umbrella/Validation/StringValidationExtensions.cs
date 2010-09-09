using System;
using nVentive.Umbrella.Validation;

namespace nVentive.Umbrella.Extensions
{
	public static class StringValidationExtensions
	{
		public static string NotNullOrEmpty(this ValidationExtensionPoint<string> extension, string name)
		{
			if (extension.ExtendedValue.IsNullOrEmpty())
			{
				throw new ArgumentNullException(name);
			}
			return extension.ExtendedValue;
		}
	}
}
