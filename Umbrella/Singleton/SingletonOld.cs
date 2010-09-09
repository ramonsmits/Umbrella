using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using nVentive.Framework.Configuration;

namespace nVentive.Framework.Patterns.Singleton
{
    public static class SingletonOld
    {
        private static T instance; //TODO Figure out volatile.
        private static readonly object syncRoot = new object();
        private static string configurationSourceName;

        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    lock(syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = Create();
                        }
                    }
                }

                return instance;
            }
            set 
            {
                lock (syncRoot)
                {
                    instance = value;
                }
            }
        }

        public static string ConfigurationSourceName
        {
            get { return configurationSourceName; }
            set { configurationSourceName = value; }
        }

        private static T Create()
        {
            SingletonSettings settings = GetSettings();

            SingletonTypeMappingData data = settings.Mappings.First(mapping => (mapping.Type == typeof(T)));

            return (T)Activator.CreateInstance(data.ConcreteType);
        }

        private static SingletonSettings GetSettings()
        {
            return ConfigurationSourceExtensions.GetSection<SingletonSettings>(ConfigurationSourceName, SingletonSettings.SectionName);
        }
    }
}
