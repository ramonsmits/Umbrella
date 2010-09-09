using System.Collections.Generic;
using nVentive.Umbrella.Extensions;
using nVentive.Umbrella.Locator;

namespace nVentive.Umbrella.Components
{
    /// <summary>
    /// A component.
    /// </summary>
    public class Component : IComponent
    {
        private IServiceLocator locator;

        protected virtual IEnumerable<object> Fields
        {
            get { return null; }
        }

        #region IComponent Members

        /// <summary>
        /// An accessor for the Context.
        /// </summary>
        public virtual IServiceLocator ServiceLocator
        {
            get { return locator ?? Locator.ServiceLocator.Instance; }
            set { locator = value; }
        }

        #endregion

        public override int GetHashCode()
        {
            var fields = Fields;

            return fields == null ? base.GetHashCode() : this.Equality().GetHashCode(Fields);
        }

        public override bool Equals(object obj)
        {
            var other = obj as Component;

            if (other == null)
            {
                return false;
            }

            var fields = Fields;
            var otherFields = other.Fields;

            if (fields == null || otherFields == null)
            {
                return false;
            }

            return fields.Equality().Equal(otherFields);
        }
    }
}