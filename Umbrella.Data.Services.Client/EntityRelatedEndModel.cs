using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Data.Services.Client;
using System.ComponentModel;
using nVentive.Umbrella.Extensions;

namespace nVentive.Treatments.Model
{
    public class EntityRelatedEndModel<TContext, TSourceModel, TSourceEntity, TTargetModel, TTargetEntity>: ISynchronizableModel
        where TContext : DataServiceContext
        where TSourceModel : EntityDataServiceModel<TContext, TSourceEntity>
        where TTargetModel : EntityDataServiceModel<TContext, TTargetEntity>
        where TSourceEntity : class, new()
        where TTargetEntity : class, new()
    {
        public EntityRelatedEndModel(
            TSourceModel source,
            TTargetModel target,
            Expression<Func<TSourceEntity, TTargetEntity>> selector)
        {
            Source = source;
            Target = target;
            Selector = selector;

            Synchronize();

            Target.PropertyChanged += new PropertyChangedEventHandler(Target_PropertyChanged);
        }

        public TSourceModel Source { get; private set; }
        public TTargetModel Target { get; private set; }

        public Expression<Func<TSourceEntity, TTargetEntity>> Selector { get; private set; }

        public TContext Context
        {
            get { return Source.Context; }
        }

        public string PropertyName
        {
            get { return Selector.GetSelectedMemberName(); }
        }

        private void Target_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Source.Entity.Reflection().Set(PropertyName, Target.Entity);

            Context.SetLink(Source.Entity, PropertyName, Target.Entity);
        }

        #region ISynchronizedModel Members

        public void Synchronize()
        {
            Target.Entity = Source.Entity.Reflection().Get<TTargetEntity>(PropertyName);
        }

        #endregion
    }
}
