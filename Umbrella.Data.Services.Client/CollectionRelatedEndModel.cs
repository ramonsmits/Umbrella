using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Services.Client;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq.Expressions;
using nVentive.Umbrella.Extensions;
using nVentive.Umbrella.Events;

namespace nVentive.Treatments.Model
{
    //TODO Rename to OneToManyRelatedEndModel
    public class CollectionRelatedEndModel<TContext, TSourceModel, TSourceEntity, TTargetModel, TTargetEntity>
        where TContext : DataServiceContext
        where TSourceModel : EntityDataServiceModel<TContext, TSourceEntity>
        where TTargetModel : EntityDataServiceModel<TContext, TTargetEntity>, new()
        where TSourceEntity : class, new()
        where TTargetEntity : class, new()
    {
        public CollectionRelatedEndModel(
            TSourceModel source,
            Expression<Func<TSourceEntity, ICollection<TTargetEntity>>> sourceSelector,
            Expression<Func<TTargetEntity, TSourceEntity>> targetSelector)
        {
            Source = source;
            SourceSelector = sourceSelector;
            TargetSelector = targetSelector;

            Targets = new ObservableCollection<TTargetModel>();

            LoadExistingItems();

            Targets.CollectionChanged += new NotifyCollectionChangedEventHandler(Targets_CollectionChanged);
        }

        public TContext Context
        {
            get { return Source.Context; }
        }

        public TSourceModel Source { get; private set; }

        public ObservableCollection<TTargetModel> Targets { get; private set; }

        public string SourcePropertyName
        {
            get { return TargetSelector.GetSelectedMemberName(); }
        }

        public string TargetPropertyName
        {
            get { return SourceSelector.GetSelectedMemberName(); }
        }

        public Expression<Func<TSourceEntity, ICollection<TTargetEntity>>> SourceSelector { get; private set; }
        public Expression<Func<TTargetEntity, TSourceEntity>> TargetSelector { get; private set; }

        public ICollection<TTargetEntity> Collection
        {
            get { return SourceSelector.Compile()(Source.Entity); }
        }

        private void Targets_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                TTargetModel model = (TTargetModel)e.NewItems[0];
                model.PropertyChanged += new PropertyChangedEventHandler(model_PropertyChanged);
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                TTargetModel model = (TTargetModel)e.OldItems[0];
                model.PropertyChanged -= new PropertyChangedEventHandler(model_PropertyChanged);
                
                RemoveLink(model.Entity);
            }
        }

        private void model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Entity")
            {
                ExtendedPropertyChangedEventArgs<TTargetEntity> args = e as ExtendedPropertyChangedEventArgs<TTargetEntity>;

                args.OldValue.Maybe(() => RemoveLink(args.OldValue));
                
                AddLink(args.NewValue);
            }
        }

        private void LoadExistingItems()
        {
            foreach (var item in Collection)
            {
                Targets.Add(new TTargetModel { Entity = item });

                SetParent(item);
            }
        }

        private void AddLink(TTargetEntity entity)
        {
            if (SourcePropertyName.HasValue())
            {
                entity.Reflection().Set(SourcePropertyName, Source.Entity);
            }

            Collection.Add(entity);

            Context.AddLink(Source.Entity, TargetPropertyName, entity);
        }

        private void RemoveLink(TTargetEntity entity)
        {
            SetParent(entity);

            Collection.Remove(entity);

            Context.DeleteLink(Source.Entity, TargetPropertyName, entity);
        }

        private void SetParent(TTargetEntity entity)
        {
            if (SourcePropertyName.HasValue())
            {
                entity.Reflection().Set(SourcePropertyName, default(TSourceEntity));
            }
        }
    }
}
