using System;
using System.Collections.Generic;
using nVentive.Umbrella.Components;
using nVentive.Umbrella.Extensions;

namespace nVentive.Umbrella.Containers
{
    public class Container : Component, IContainer, IDisposable
    {
        private readonly ICollection<object> disposable = new List<object>();
        private readonly Dictionary<string, object> values = new Dictionary<string, object>();
        private ContainerExtensionPoint sourceExtensionPoint;
        private ContainerExtensionPoint valueExtensionPoint;

        public ContainerExtensionPoint Sources
        {
            get
            {
                if (sourceExtensionPoint == null)
                {
                    sourceExtensionPoint = new ContainerExtensionPoint(this, ContentType.Source);
                }

                return sourceExtensionPoint;
            }
        }

        public ContainerExtensionPoint Values
        {
            get
            {
                if (valueExtensionPoint == null)
                {
                    valueExtensionPoint = new ContainerExtensionPoint(this, ContentType.Value);
                }

                return valueExtensionPoint;
            }
        }

        public ICollection<object> Disposable
        {
            get { return disposable; }
        }

        #region IContainer Members

        IDictionary<string, object> IContainer.Values
        {
            get { return values; }
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        ~Container()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            foreach (var item in disposable)
            {
                item.Extensions().Dispose();
            }
        }
    }
}