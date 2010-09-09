using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nVentive.Umbrella.Sources;

namespace nVentive.Umbrella.Contracts
{
    public interface IContractExtensions
    {
        IContract Add(IContract x, IContract y);
        T Find<T>(IContract contract) where T : IContract;
        T Get<T>(IContract contract) where T : IContract;
        TValue GetValueOrDefault<TContract, TValue>(IContract contract) where TContract : ISource<TValue>, IContract;
    }
}
