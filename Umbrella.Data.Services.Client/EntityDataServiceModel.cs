using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nVentive.Umbrella.Sources;
using System.Data.Services.Client;
using System.Linq.Expressions;
using nVentive.Umbrella;
using nVentive.Umbrella.Edm;
using System.Reflection;
using nVentive.Umbrella.Extensions;
using System.ComponentModel;
using nVentive.Umbrella.Events;
using System.Collections.ObjectModel;

namespace nVentive.Treatments.Model
{
    public interface ISynchronizableModel
    {
        void Synchronize();
    }

    public class EntityDataServiceModel<TContext, TEntity> : DataServiceModel<TContext>, INotifyPropertyChanged
        where TContext : DataServiceContext
        where TEntity : class, new()
    {
        private TEntity entity;
        private Dictionary<string, ISynchronizableModel> synchronizationModels = new Dictionary<string, ISynchronizableModel>();

        public TRelatedModel GetRelated<TRelatedModel, TRelatedEntity>(
            Expression<Func<TEntity, TRelatedEntity>> selector)
            where TRelatedModel : EntityDataServiceModel<TContext, TRelatedEntity>, new()
            where TRelatedEntity : class, new()
        {
            string memberName = selector.GetSelectedMemberName();

            var model = GetRelated<TRelatedModel>(memberName);

            if (!synchronizationModels.ContainsKey(memberName))
            {
                //TODO Only create the 1st time.
                var relationship = new EntityRelatedEndModel<TContext, EntityDataServiceModel<TContext, TEntity>, TEntity, TRelatedModel, TRelatedEntity>(
                    this,
                    model,
                    selector);

                synchronizationModels.Add(memberName, relationship);
            }

            return model;
        }

        public ObservableCollection<TRelatedModel> GetRelated<TRelatedModel, TRelatedEntity>(
            Expression<Func<TEntity, ICollection<TRelatedEntity>>> sourceSelector,
            Expression<Func<TRelatedEntity, TEntity>> targetSelector)
            where TRelatedModel : EntityDataServiceModel<TContext, TRelatedEntity>, new()
            where TRelatedEntity : class, new()
        {
            var model = GetRelated<CollectionRelatedEndModel<
                                    TContext, 
                                    EntityDataServiceModel<TContext, TEntity>, 
                                    TEntity, 
                                    TRelatedModel, 
                                   TRelatedEntity>>(
                sourceSelector.GetSelectedMemberName(),
                () => new CollectionRelatedEndModel<
                            TContext, 
                            EntityDataServiceModel<TContext, TEntity>, TEntity, 
                            TRelatedModel,
                            TRelatedEntity>(this, sourceSelector, targetSelector));

            return model.Targets;
        }

        public TEntity Entity
        {
            get { return entity; }
            set
            {
                TEntity previousEntity = entity;

                entity = value;
                
                this.Notify(PropertyChanged, x => x.Entity, previousEntity, entity);
            }
        }

        //TODO If Dispose is called without a Save, we must detach those entities.
        public virtual TEntity New()
        {
            var newEntity = new TEntity();

            Edit(newEntity);

            //TODO Check if we really have to call Entity setter after Edit (because of AddObject before NotifyPropertyChanged is raised.
            Entity = newEntity;

            return Entity;
        }

        public void Edit()
        {
            Edit(Entity);
        }

        private void Edit(TEntity entity)
        {
            IIdentifiable identifiable = entity as IIdentifiable;

            if (identifiable != null &&
                identifiable.Id == Guid.Empty)
            {
                Context.AddObject(EntitySetName, entity);
            }
            else
            {
                Context.AttachTo(EntitySetName, entity);
            }
        }

        public void Load(params Expression<Func<TEntity, object>>[] expanders)
        {
            foreach (var expander in expanders)
            {
                string memberName = expander.GetSelectedMemberName();

                Context.LoadProperty(Entity, memberName);

                ISynchronizableModel model = synchronizationModels.GetValueOrDefault(memberName);

                if (model != null)
                {
                    model.Synchronize();
                }
            }
        }

        public virtual TEntity Load(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] expanders)
        {
            DataServiceQuery<TEntity> query = Context.CreateQuery<TEntity>(EntitySetName);

            query = query.Expand(expanders);

            IQueryable<TEntity> queryable = query.Where(predicate);

            TEntity existing = query.SingleOrDefault();

            if (existing != null)
            {
                Entity = existing;
            }

            return Entity;
        }

        public void Save()
        {
            IIdentifiable identifiable = Entity as IIdentifiable;

            if (identifiable != null &&
                identifiable.Id == Guid.Empty)
            {
                identifiable.Id = Guid.NewGuid();
            }

            Scope.Completed = true;
        }

        public void Delete()
        {
            Context.DeleteObject(Entity);
        }

        protected virtual string EntitySetName
        {
            get { return EntitySetExtensions.GetEntitySetName(typeof(TEntity)); }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}
