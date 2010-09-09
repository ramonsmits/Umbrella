using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nVentive.Umbrella.Sources;
using nVentive.Umbrella.Extensions;
using nVentive.Umbrella.Values;

namespace nVentive.Umbrella.Containers
{
    public class DefaultContainerExtensions : IContainerExtensions
    {
        #region IContainerExtensions Members
        
        public virtual T Get<T>(ContainerExtensionPoint container, string key)
        {
        }

        public virtual T Get<T>(ContainerExtensionPoint container, string key, Func<T> factory)
        {

        }

        public virtual void Set<T>(ContainerExtensionPoint container, string key, T value)
        {
        }

        public virtual void Set<T>(ContainerExtensionPoint container, string key, Func<T> factory, T value)
        {
        }

        public virtual IValue<T> GetValue<T>(IContainer container, string key)
        {
        }

        public virtual ILazyValue<T> GetValue<T>(IContainer container, string key, Func<T> factory)
        {
        }

        public virtual IValue<T> GetValue<T>(IContainer container, string key, Func<IValue<T>> factory)
        {
        }

        public virtual ISource<T> GetSource<T>(IContainer container, string key)
        {
        }

        public virtual ILazySource<T> GetSource<T>(IContainer container, string key, Func<T> factory)
        {
        }

        public virtual ISource<T> GetSource<T>(IContainer container, string key, Func<ISource<T>> factory)
        {
        }

        #endregion
    }
}
