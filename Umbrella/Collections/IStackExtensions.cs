using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nVentive.Umbrella.Collections
{
    public interface IStackExtensions
    {
        T PeekOrDefault<T>(Stack<T> stack);

        IDisposable Subscribe<T>(Stack<T> stack, T value);
    }
}
