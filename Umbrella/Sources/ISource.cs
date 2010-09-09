namespace nVentive.Umbrella.Sources
{
    public interface ISource<T>
    {
        T Value { get; set; }
    }
}