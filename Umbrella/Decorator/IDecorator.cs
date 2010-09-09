namespace nVentive.Umbrella.Decorator
{
    /// <summary>
    /// The interface for the interface Decorator pattern.
    /// </summary>
    /// <typeparam name="T">The type to decorate.</typeparam>
    public interface IDecorator<T>
    {
        /// <summary>
        /// An accessor for the target T.
        /// </summary>
        T Target { get; set; }
    }
}