using System;

namespace nVentive.Umbrella.Sources
{
    public interface IDisposableSource<T> : ISource<T>, IDisposable
    {
    }
}