using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nVentive.Umbrella.Contracts;
using nVentive.Umbrella.Extensions;

namespace nVentive.Umbrella.Factories
{
    public class ArrayFactoryStrategy : FactoryStrategyBase
    {
        protected override bool CanFullfill(Type type, string name, IContract contract)
        {
            int length;
            return type.IsArray && Extract(contract, out length);
        }

        protected override T GenericCreate<T>(string name, IContract contract)
        {
            int length;
            Extract(contract, out length);

            return (T)(object)Array.CreateInstance(typeof(T).GetElementType(), length);
        }

        protected virtual bool Extract(IContract contract, out int length)
        {
            ConstructorInjectionContract args = contract.Find<ConstructorInjectionContract>();

            if (args == null)
            {
                length = -1;
                return false;
            }
            else
            {
                length = (int)args.Value.First();
                return true;
            }
        }
    }
}
