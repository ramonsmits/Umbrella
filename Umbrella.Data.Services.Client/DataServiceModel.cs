using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Services.Client;
using nVentive.Umbrella.Sources;
using System.Linq.Expressions;
using System.Configuration;
using nVentive.Umbrella.Extensions;
using nVentive.Umbrella.Contexts;
using nVentive.Umbrella.Collections;
using nVentive.Umbrella;
using nVentive.Umbrella.Edm;
using nVentive.Umbrella.Expressions;

namespace nVentive.Treatments.Model
{
    public class DataServiceModel<TContext> : IDisposable
        where TContext : DataServiceContext
    {
        //public static IEnumerable<TModel> Load<TModel, TEntity>(params Expression<Func<TEntity, object>>[] expanders)
        //    where TModel : EntityDataServiceModel<TContext, TEntity>, new()
        //    where TEntity : class, new()
        //{
        //    return Load<TModel, TEntity, TEntity>(expanders);
        //}

        //public static IEnumerable<TModel> Load<TModel, TEntity>(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] expanders)
        //    where TModel : EntityDataServiceModel<TContext, TEntity>, new()
        //    where TEntity : class, new()
        //{
        //    return Load<TModel, TEntity, TEntity>(predicate, expanders);
        //}

        //public static IEnumerable<TModel> Load<TModel, TEntityBase, TEntity>(params Expression<Func<TEntityBase, object>>[] expanders)
        //    where TModel : EntityDataServiceModel<TContext, TEntity>, new()
        //    where TEntity : class, TEntityBase, new()
        //{
        //    return Load<TModel, TEntityBase, TEntity>(Expressions<TEntityBase>.True, expanders);
        //}

        //public static IEnumerable<TModel> Load<TModel, TEntityBase, TEntity>(Expression<Func<TEntityBase, bool>> predicate, params Expression<Func<TEntityBase, object>>[] expanders)
        //    where TModel : EntityDataServiceModel<TContext, TEntity>, new()
        //    where TEntity : class, TEntityBase, new()
        //{
        //    using (IContextScope<TContext> scope = new ContextScope<TContext>())
        //    {
        //        string entitySetName = EntitySetExtensions.GetEntitySetName(typeof(TEntity));

        //        DataServiceQuery<TEntityBase> query = scope.Context.CreateQuery<TEntityBase>(entitySetName);

        //        query.Expand(expanders);

        //        IQueryable<TEntityBase> queryable = query;

        //        if (predicate != Expressions<TEntityBase>.True)
        //        {
        //            queryable = queryable.Where(predicate);
        //        }

        //        if (typeof(TEntityBase) != typeof(TEntity))
        //        {
        //            var parameter = Expression.Parameter(typeof(TEntityBase), "item");
        //            var typeIs = Expression.Lambda<Func<TEntityBase, bool>>(Expression.TypeIs(parameter, typeof(TEntity)), parameter);

        //            queryable = queryable.Where(typeIs);
        //        }

        //        foreach (TEntity entity in queryable)
        //        {
        //            yield return new TModel { Entity = entity };
        //        }
        //    }
        //}

        private Dictionary<object, object> models = new Dictionary<object, object>();

        protected ILazySource<IContextScope<TContext>> scope = new LazySource<IContextScope<TContext>>(LazyBehavior.Null, () => new ContextScope<TContext>());

        public TContext Context
        {
            get { return Scope.Context; }
        }

        public IContextScope<TContext> Scope
        {
            get { return scope.Value; }
        }

        #region IDisposable Members

        public void Dispose()
        {
            if (scope.IsLoaded)
            {
                scope.Value.Dispose();
            }

            scope.Value = null;
        }

        #endregion

        public TModel GetRelated<TModel>(string name)
            where TModel : class, new()
        {
            return GetRelated<TModel>(name, () => new TModel());
        }

        public TModel GetRelated<TModel>(string name, Func<TModel> factory)
            where TModel : class
        {
            return models.FindOrCreate(
                new Key(typeof(TModel), name), 
                () => factory()) as TModel;
        }
    }
}
