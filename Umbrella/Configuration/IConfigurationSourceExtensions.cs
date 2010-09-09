using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;

namespace nVentive.Umbrella.EnterpriseLibrary.Configuration
{
    public interface IConfigurationSourceExtensions
    {
        T FindSection<T>(IConfigurationSource configSource, string sectionName)
            where T : ConfigurationSection;

    }
}
