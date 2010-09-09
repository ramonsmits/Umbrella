using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nVentive.Umbrella.Sources;

namespace nVentive.Umbrella.Contexts
{
    public class ContextScopeMediator<TContext>
    {
        private static ISource<IContextScopeMediator<TContext>> scope;

        public static readonly ICollection<IContextScopeHandler<TContext>> Handlers = new List<IContextScopeHandler<TContext>>();

        public static IContextScopeMediator<TContext> Current
        {
            get { return scope.Value; }
        }

        public static Func<IContextScopeMediator<TContext>> Factory
        {
            set
            {
                scope = new LazySource<IContextScopeMediator<TContext>>(
                            new ThreadLocalSource<IContextScopeMediator<TContext>>(),
                                LazyBehavior.Default,
                                value);
            }
        }

        public static IContextScope<TContext> CurrentScope
        {
            get { return (IContextScope<TContext>)Current.Scopes.LastOrDefault(); }
        }

        public static TContext CurrentContext
        {
            get { return Current.Context; }
        }
    }
}
