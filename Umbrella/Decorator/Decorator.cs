using System;

namespace nVentive.Umbrella.Decorator
{
    /// <summary>
    /// A implementation of IDecorator.
    /// </summary>
    /// <typeparam name="T">The type to decorate.</typeparam>
    [Serializable]
    public class Decorator<T> : IDecorator<T>
    {
        /// <summary>
        /// Constructs a new Decorator for a default(T) target.
        /// </summary>
        public Decorator()
            : this(default(T))
        {
        }

        /// <summary>
        /// Constructs a new Decorator for a specified target.
        /// </summary>
        /// <param name="target">The target.</param>
        public Decorator(T target)
        {
            // TODO: Accessing virtual methods within constructor
            Target = target;
        }

        #region IDecorator<T> Members

        /// <summary>
        /// See base.
        /// </summary>
        public virtual T Target { get; set; }

        #endregion
    }
}