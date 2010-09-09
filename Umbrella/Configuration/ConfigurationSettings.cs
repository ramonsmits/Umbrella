using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;

using nVentive.Umbrella.Provider;
using nVentive.Umbrella.Sources;
using nVentive.Umbrella.Extensions;
using nVentive.Umbrella.Contexts;

namespace nVentive.Umbrella.EnterpriseLibrary.Configuration
{
    public class ConfigurationSettings<T> : LazySource<T>, IConfigurableSource<T>
        where T : ConfigurationSection
    {
        private string sourceName;
        private string sectionName;

        public ConfigurationSettings()
            : this(null)
        {
        }

        public ConfigurationSettings(string sectionName)
        {
            SectionName = sectionName;
        }

        public virtual string SourceName
        {
            get { return sourceName; }
            set
            {
                sourceName = value;
                IsLoaded = false;
            }
        }

        public virtual string SectionName
        {
            get { return sectionName; }
            set
            {
                sectionName = value;
                IsLoaded = false;
            }
        }

        protected virtual IConfigurationSource ConfigurationSource
        {
            get { return ConfigurationSourceFactoryStrategy.Create(SourceName); }
        }


        protected override Func<T> Factory
        {
            get { return () => (T)ConfigurationSource.GetSection(SectionName); }
        }
    }
}
