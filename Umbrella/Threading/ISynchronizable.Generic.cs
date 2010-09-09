namespace nVentive.Umbrella.Threading
{
    public interface ISynchronizable<T>
    {
        ISynchronizableLock<T> Lock { get; }
    }
}