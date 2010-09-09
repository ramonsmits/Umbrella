using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nVentive.Umbrella.Sources;
using nVentive.Umbrella.Extensions;

namespace nVentive.Umbrella.Contexts
{
    public abstract class ContextScopeMediatorBase<TContext> : IContextScopeMediator<TContext>
    {
        private List<IContextScope> scopes = new List<IContextScope>();

        public ContextScopeMediatorBase()
        {
            ContextSource = new LazySource<TContext>(LazyBehavior.Null, CreateContext);
            ContextSource.Loaded += new EventHandler<EventArgs>(ContextSource_Loaded);
        }

        public TContext Context
        {
            get
            {
                if (scopes.Empty())
                {
                    return default(TContext);
                }

                return ContextSource.Value;
            }
        }

        object IContextScopeMediator.Context
        {
            get { return Context; }
        }

        public IDisposable Subscribe(IContextScope scope)
        {
            scopes.Add(scope);

            return Actions.Create(() => Dispose(scope)).ToDisposable();
        }

        public IEnumerable<IContextScope> Scopes
        {
            get { return scopes; }
        }

        public bool? OverallVote
        {
            get;
            set;
        }

        protected LazySource<TContext> ContextSource
        {
            get;
            private set;
        }

        protected virtual TContext CreateContext()
        {
            return typeof(TContext).New<TContext>();
        }

        protected virtual void DisposeContext()
        {
            if (OverallVote == true)
            {
                SaveContext();
            }

            ContextSource.Value.Extensions().Dispose();
            ContextScopeMediator<TContext>.Handlers.ForEach(item => item.Context = default(TContext));
            ContextSource.Value = default(TContext);
        }

        protected abstract void SaveContext();

        private void ContextSource_Loaded(object sender, EventArgs e)
        {
            ContextScopeMediator<TContext>.Handlers.ForEach(item => item.Context = ContextSource.Value);
        }

        private void Dispose(IContextScope scope)
        {
            scopes.Remove(scope);

            Vote(scope);

            if (scopes.Empty())
            {
                if (ContextSource.IsLoaded)
                {
                    DisposeContext();
                }

                OverallVote = null;
            }
        }

        private void Vote(IContextScope scope)
        {
            if (scope.Completed == true &&
                OverallVote == false)
            {
                throw new InvalidOperationException("Cannot vote to complete as the scope has already been voted to rollback");
            }

            if (scope.Completed.HasValue)
            {
                OverallVote = scope.Completed;
            }
        }
    }
}
