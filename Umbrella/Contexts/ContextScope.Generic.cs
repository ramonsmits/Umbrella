using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nVentive.Umbrella.Contexts
{
    public class ContextScope<TContext> : IContextScope<TContext>
    {
        private IDisposable subscription;

        public ContextScope()
            : this(ContextScopeMediator<TContext>.Current)
        {
        }

        public ContextScope(IContextScopeMediator<TContext> mediator)
        {
            Mediator = mediator;
            subscription = Mediator.Subscribe(this);
        }

        object IContextScope.Context
        {
            get { return Mediator.Context; }
        }

        public IContextScopeMediator<TContext> Mediator
        {
            get;
            private set;
        }

        public TContext Context
        {
            get { return Mediator.Context; }
        }

        public bool? Completed
        {
            get;
            set;
        }

        public virtual void Dispose()
        {
            subscription.Dispose();
        }
    }
}
