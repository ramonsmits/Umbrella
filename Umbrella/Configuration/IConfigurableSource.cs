using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nVentive.Umbrella.Sources;

namespace nVentive.Umbrella.EnterpriseLibrary.Configuration
{
    public interface IConfigurableSource<T> : ISource<T>
    {
        string SourceName { get; set; }
        string SectionName { get; set; }
    }
}
