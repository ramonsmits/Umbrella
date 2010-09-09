namespace nVentive.Umbrella.Reflection
{
    public interface IEventDescriptor : IMemberDescriptor
    {
        IMethodDescriptor Add { get; }
        IMethodDescriptor Remove { get; }
    }
}