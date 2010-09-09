using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nVentive.Umbrella.Contexts;
using System.Data.Services.Client;
using nVentive.Umbrella.Extensions;

namespace nVentive.Umbrella.Data.Services.Client
{
    public class DataServiceContextScopeMediator<TContext> : ContextScopeMediatorBase<TContext>
        where TContext : DataServiceContext
    {
        public Uri Uri { get; set; }

        protected override TContext CreateContext()
        {
            return typeof(TContext).New<TContext>(Uri);
        }

        protected override void SaveContext()
        {
            ContextSource.Value.SaveChanges(SaveChangesOptions.Batch);
        }
    }

}
