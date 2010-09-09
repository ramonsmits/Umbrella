using System;
using System.Collections.Generic;

namespace nVentive.Umbrella.Extensions
{
    public static class StackExtensions
    {
        public static T PeekOrDefault<T>(this Stack<T> stack)
        {
            return stack.Empty() ? default(T) : stack.Peek();
        }

        public static IDisposable Subscribe<T>(this Stack<T> stack, T value)
        {
            stack.Push(value);

            return Actions.Create(() => stack.Pop()).ToDisposable();
        }
    }
}