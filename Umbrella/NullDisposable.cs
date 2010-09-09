using System;

namespace nVentive.Umbrella
{
    /// <summary>
    /// An empty implementation of the IDisposable class.
    /// </summary>
    public class NullDisposable : IDisposable
    {
        /// <summary>
        /// Provider for a instance of the NullDisposable
        /// </summary>
        public static readonly IDisposable Instance = new NullDisposable();

        /// <summary>
        /// Private constructor, use Instance.
        /// </summary>
        private NullDisposable()
        {
        }

        #region IDisposable Members

        /// <summary>
        /// See IDisposable.
        /// </summary>
        public void Dispose()
        {
        }

        #endregion
    }
}