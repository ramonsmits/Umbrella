using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EnterpriseLibraryContrib.Validation;
using EnterpriseLibraryContrib.Validation.Validators;


namespace Nventive.Framework.Validation
{
    public static class Validations
    {
        //TODO Use Strategy?
        // Use as Extension Method on IValidation<T>? and provide object.Validation().NotNull(string argumentName)
        public static T NotNull<T>(string argumentName, T value)
        {
            ArgumentValidation.Validate(argumentName, value, DefaultValidators.NotNullValidator);
            return value;
        }
    }
}
