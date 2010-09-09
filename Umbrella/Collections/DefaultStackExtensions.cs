using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nVentive.Umbrella.Extensions;

namespace nVentive.Umbrella.Collections
{
    public class DefaultStackExtensions : IStackExtensions
    {
        #region IStackExtensions Members

        public virtual T PeekOrDefault<T>(Stack<T> stack)
        {
            return stack.Empty() ? default(T) : stack.Peek();
        }

        public virtual IDisposable Subscribe<T>(Stack<T> stack, T value)
        {
            stack.Push(value);

            return Actions.Create(() => stack.Pop()).ToDisposable();
        }

        #endregion
    }
}
