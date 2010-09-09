using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ObjectBuilder;

using nVentive.Framework.Collections;
using nVentive.Framework.Patterns.Composite;

namespace nVentive.Framework.ObjectBuilder
{
    public class CompositePolicyList : Composite<IPolicyList>, IPolicyList
    {
        #region IPolicyList Members

        public void Clear(Type policyInterface, object buildKey)
        {
            //Items.ForEach(item => item.Clear(policyInterface, buildKey));
            throw new NotSupportedException();
        }

        public void Clear<TPolicyInterface>(object buildKey)
        {
            //Items.ForEach(item => item.Clear<TPolicyInterface>(buildKey));
            throw new NotSupportedException();
        }

        public void ClearAll()
        {
            //Items.ForEach(item => item.ClearAll());
            throw new NotSupportedException();
        }

        public void ClearDefault(Type policyInterface)
        {
            //Items.ForEach(item => item.ClearDefault(policyInterface));
            throw new NotSupportedException();
        }

        public void ClearDefault<TPolicyInterface>()
        {
            //Items.ForEach(item => item.ClearDefault<TPolicyInterface>());
            throw new NotSupportedException();
        }

        public IBuilderPolicy Get(Type policyInterface, object buildKey, bool localOnly)
        {
            return Items.Select(item => item.Get(policyInterface, buildKey, localOnly)).First(item => item != null);
        }

        public TPolicyInterface Get<TPolicyInterface>(object buildKey, bool localOnly) where TPolicyInterface : IBuilderPolicy
        {
            return Items.Select(item => item.Get<TPolicyInterface>(buildKey, localOnly)).FirstOrDefault(item => item != null);
        }

        public IBuilderPolicy Get(Type policyInterface, object buildKey)
        {
            return Items.Select(item => item.Get(policyInterface, buildKey)).First(item => item != null);
        }

        public TPolicyInterface Get<TPolicyInterface>(object buildKey) where TPolicyInterface : IBuilderPolicy
        {
            return Items.Select(item => item.Get<TPolicyInterface>(buildKey)).FirstOrDefault(item => item != null);
        }

        public IBuilderPolicy GetNoDefault(Type policyInterface, object buildKey, bool localOnly)
        {
            return Items.Select(item => item.GetNoDefault(policyInterface, buildKey, localOnly)).First(item => item != null);
        }

        public TPolicyInterface GetNoDefault<TPolicyInterface>(object buildKey, bool localOnly) where TPolicyInterface : IBuilderPolicy
        {
            return Items.Select(item => item.GetNoDefault<TPolicyInterface>(buildKey, localOnly)).FirstOrDefault(item => item != null);
        }

        public void Set(Type policyInterface, IBuilderPolicy policy, object buildKey)
        {
            throw new NotSupportedException();
        }

        public void Set<TPolicyInterface>(TPolicyInterface policy, object buildKey) where TPolicyInterface : IBuilderPolicy
        {
            throw new NotSupportedException();
        }

        public void SetDefault(Type policyInterface, IBuilderPolicy policy)
        {
            throw new NotSupportedException();
        }

        public void SetDefault<TPolicyInterface>(TPolicyInterface policy) where TPolicyInterface : IBuilderPolicy
        {
            throw new NotSupportedException();
        }

        #endregion
    }
}
