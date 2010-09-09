using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nVentive.Umbrella.Sources;
using nVentive.Umbrella.Values;

namespace nVentive.Umbrella.Containers
{
    public interface IContainerExtensions
    {
        T Get<T>(ContainerExtensionPoint container, string key);
        T Get<T>(ContainerExtensionPoint container, string key, Func<T> factory);
        
        void Set<T>(ContainerExtensionPoint container, string key, T value);
        void Set<T>(ContainerExtensionPoint container, string key, Func<T> factory, T value);
        
        IValue<T> GetValue<T>(IContainer container, string key);
        ILazyValue<T> GetValue<T>(IContainer container, string key, Func<T> factory);
        IValue<T> GetValue<T>(IContainer container, string key, Func<IValue<T>> factory);
        
        ISource<T> GetSource<T>(IContainer container, string key);
        ILazySource<T> GetSource<T>(IContainer container, string key, Func<T> factory);
        ISource<T> GetSource<T>(IContainer container, string key, Func<ISource<T>> factory);
    }
}
