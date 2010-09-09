using System;
using nVentive.Umbrella.Extensions;

namespace nVentive.Umbrella.Sources
{
    public class EnvironmentSource : ISource<string>
    {
        private readonly string key;
        private readonly EnvironmentVariableTarget target;

        public EnvironmentSource(string key)
            : this(key, EnvironmentVariableTarget.Process)
        {
        }

        public EnvironmentSource(string key, EnvironmentVariableTarget target)
        {
            this.key = key.Validation().NotNull("key");

            this.target = target;
        }

        #region ISource<string> Members

        public virtual string Value
        {
            get { return Environment.GetEnvironmentVariable(key, target); }
            set { Environment.SetEnvironmentVariable(key, value, target); }
        }

        #endregion
    }
}