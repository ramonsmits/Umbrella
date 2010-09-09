using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nVentive.Umbrella.Security
{
    public interface IAuthenticationService
    {
        Guid Identity { get; }
    }
}
