using nVentive.Umbrella.Contracts;

namespace nVentive.Umbrella.Factories
{
    public class WrapContract : SourceContract<object>
    {
        public WrapContract(object existing)
            : base(existing)
        {
        }
    }
}