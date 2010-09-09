using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnterpriseLibraryContrib.Validation;
using EnterpriseLibraryContrib.Validation.Validators;

namespace nVentive.Umbrella.Validation
{
    public class DefaultValidationExtensions : IValidationExtensions
    {
        #region IValidationExtensions Members

        public virtual ValidationExtensionPoint<T> Validation<T>(T value)
        {
        }

        public virtual T NotNull<T>(ValidationExtensionPoint<T> extensionPoint, string name)
        {
            ArgumentValidation.Validate(name, extensionPoint.ExtendedValue, DefaultValidators.NotNullValidator);

            return extensionPoint.ExtendedValue;
        }

        public virtual T Found<T>(ValidationExtensionPoint<T> extensionPoint)
        {
        }

        public virtual void NotSupported<T>(ValidationExtensionPoint<T> extensionPoint)
        {
            throw new NotSupportedException();
        }

        #endregion
    }
}
