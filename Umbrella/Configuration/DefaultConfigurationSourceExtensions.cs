using System.Configuration;
using System.Linq;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using nVentive.Umbrella.Extensions;
using nVentive.Umbrella.Sources;

namespace nVentive.Umbrella.EnterpriseLibrary.Configuration
{ 
    public class DefaultConfigurationSourceExtensions : IConfigurationSourceExtensions
    {
        private ConfigurationSettings<ConfigurationResolverSettings> settings = new ConfigurationSettings<ConfigurationResolverSettings>("configurationResolverConfiguration");

        public ISource<ConfigurationResolverSettings> Settings
        {
            get { return settings; }
        }

        public virtual T FindSection<T>(IConfigurationSource configSource, string sectionName)
            where T : ConfigurationSection
        {
            if (sectionName.IsNullOrEmpty())
            {
                sectionName = Resolve<T>(sectionName);
            }

            if (sectionName == null)
            {
                return default(T);
            }
            else
            {
                return (T)configSource.GetSection(sectionName);
            }
        }

        protected virtual string Resolve<T>(string sectionName)
        {
            ConfigurationResolverSettings settings = Settings.Value;

            if (settings != null)
            {
                ConfigurationResolverEntryData data = settings.Sections.FirstOrDefault(section => section.Type == typeof(T));

                if (data != null)
                {
                    sectionName = data.Name;
                }
            }

            return sectionName;
        }
    }
}
