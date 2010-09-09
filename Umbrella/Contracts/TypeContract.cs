using System;

namespace nVentive.Umbrella.Contracts
{
    public class TypeContract : SourceContract<Type>
    {
        public TypeContract()
        {
        }

        public TypeContract(Type type)
            : base(type)
        {
        }
    }
}