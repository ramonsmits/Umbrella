using System;

namespace nVentive.Umbrella
{
    /// <summary>
    /// Container for stock actions.
    /// </summary>
    /// <typeparam name="T">The type of the argument for the actions.</typeparam>
    public static class Actions<T>
    {
        /// <summary>
        /// A Null action, that performs nothing.
        /// </summary>
        public static readonly Action<T> Null = item => { };
    }

    public static class Actions<T, U>
    {
        public static readonly Action<T, U> Null = (t, u) => { };
    }
}