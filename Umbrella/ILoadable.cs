using System;

namespace nVentive.Umbrella
{
    public interface ILoadable
    {
        bool IsLoaded { get; }
        event EventHandler<EventArgs> Loaded;
    }
}