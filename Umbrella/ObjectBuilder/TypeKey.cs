using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EnterpriseLibraryContrib.Validation;
using EnterpriseLibraryContrib.Validation.Validators;

using ObjectBuilder;

namespace nVentive.Framework.ObjectBuilder
{
    public class TypeKey
    {
        private Type type;

        public TypeKey(Type type)
        {
            ArgumentValidation.Validate("type", type, DefaultValidators.NotNullValidator);
            
            this.type = type;
        }

        public virtual Type Type
        {
            get { return type; }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
    }
}
