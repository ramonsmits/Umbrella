using System;

namespace nVentive.Umbrella.Reflection
{
    [Flags]
    public enum BindingBehavior
    {
        Inherited = 1,
        Interface = 2,
        All = Inherited | Interface
    }
}