using nVentive.Umbrella.Sources;

namespace nVentive.Umbrella.Contracts
{
    public class SourceContract<T> : Source<T>, IContract
    {
        public SourceContract()
        {
        }

        public SourceContract(T contract)
            : base(contract)
        {
        }
    }
}