using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Services.Client;
using System.Linq.Expressions;
using nVentive.Umbrella.Extensions;

namespace nVentive.Treatments.Model
{
    public static class DataServiceQueryExtensions
    {
        public static DataServiceQuery<T> Expand<T>(this DataServiceQuery<T> query, params Expression<Func<T, object>>[] expanders)
        {
            foreach (var expander in expanders)
            {
                query = query.Expand(expander.GetSelectedMemberName());
            }

            return query;
        }
    }
}
