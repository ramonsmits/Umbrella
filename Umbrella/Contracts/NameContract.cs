namespace nVentive.Umbrella.Contracts
{
    public class NameContract : SourceContract<string>
    {
        public NameContract()
        {
        }

        public NameContract(string name)
            : base(name)
        {
        }
    }
}