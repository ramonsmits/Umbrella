using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nVentive.Umbrella
{
    public interface IIdentifiable
    {
        Guid Id { get; set; }
    }
}
