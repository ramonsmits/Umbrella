using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;

namespace Nventive.Framework.Configuration
{
    public interface IConfigurationSourceFactory
    {
        IConfigurationSource Create(string name);
    }
}
