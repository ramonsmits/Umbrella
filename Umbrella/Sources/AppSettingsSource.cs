using System.Configuration;

namespace nVentive.Umbrella.Sources
{
    public class AppSettingsSource : ISource<string>
    {
        private readonly string key;

        public AppSettingsSource(string key)
        {
            this.key = key;
        }

        #region ISource<string> Members

        public string Value
        {
            get { return ConfigurationManager.AppSettings[key]; }
            set { throw new ReadOnlyException(); }
        }

        #endregion
    }
}