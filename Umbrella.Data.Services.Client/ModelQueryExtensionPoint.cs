//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using nVentive.Umbrella.Contexts;
//using System.Data.Services.Client;
//using System.Linq.Expressions;
//using nVentive.Umbrella.Edm;
//using nVentive.Umbrella.Expressions;

//namespace nVentive.Treatments.Model
//{
//    public class ModelScopeExtensionPoint<TContext, TModel, TEntity>
//        where TContext : DataServiceContext
//    {
//        public IContextScope<TContext> Scope { get; set; }
//    }

//    public class ModelQueryExtensionPoint<TContext, TModel, TEntity>
//        where TContext : DataServiceContext
//    {
//        public ModelScopeExtensionPoint<TContext, TModel, TEntity> Scope { get; set; }
//        public IQueryable<TEntity> Query { get; set; }
//    }

//    public static class ModelQueryExtensions
//    {
//        public static ModelQueryExtensionPoint<TContext, TModel, TEntity> Where<TContext, TModel, TEntity>(
//            this ModelScopeExtensionPoint<TContext, TModel, TEntity> extensionPoint,
//            Expression<Func<TEntity, bool>> predicate)
//            where TContext : DataServiceContext
//        {
//            string entitySetName = EntitySetExtensions.GetEntitySetName(typeof(TEntity));

//            var result = new ModelQueryExtensionPoint<TContext,TModel,TEntity> { 
//                Scope = extensionPoint,
//                Query = extensionPoint.Scope.Context.CreateQuery<TEntity>(entitySetName)};


//            if (predicate != Expressions<TEntity>.True)
//            {
//                result.Query = result.Query.Where(predicate);
//            }

//            return result;
//        }

//        public static ModelQueryExtensionPoint<TContext, TModel, TEntity> With<TContext, TModel, TEntity>(
//            this ModelScopeExtensionPoint<TContext, TModel, TEntity> extensionPoint,
//            params Expression<Func<TEntity, object>>[] expanders)
//            where TContext : DataServiceContext
//        {
//            return extensionPoint.Where(Expressions<TEntity>.True).With(expanders);
//        }

//        public static ModelQueryExtensionPoint<TContext, TModel, TEntity> With<TContext, TModel, TEntity>(
//            this ModelQueryExtensionPoint<TContext, TModel, TEntity> extensionPoint,
//            params Expression<Func<TEntity, object>>[] expanders)
//            where TContext : DataServiceContext
//        {
//            extensionPoint.Query = ((DataServiceQuery<TEntity>)extensionPoint.Query).Expand(expanders);

//            return extensionPoint;
//        }

//        public static IEnumerable<TModel> AsEnumerable<TContext, TModel, TEntity>(this ModelQueryExtensionPoint<TContext, TModel, TEntity> extensionPoint)
//            where TContext : DataServiceContext
//            where TModel : EntityDataServiceModel<TContext, TEntity>, new()
//            where TEntity : class, new()
//        {
//            return AsEnumerable<TContext, TModel, TEntity, TEntity>(extensionPoint);
//        }

//        public static IEnumerable<TModel> AsEnumerable<TContext, TModel, TEntityBase, TEntity>(this ModelQueryExtensionPoint<TContext, TModel, TEntityBase> extensionPoint)
//            where TContext : DataServiceContext
//            where TModel : EntityDataServiceModel<TContext, TEntity>, new()
//            where TEntity : class, TEntityBase, new()
//        {
//            IQueryable<TEntityBase> queryable = extensionPoint.Query;

//            if (typeof(TEntityBase) != typeof(TEntity))
//            {
//                var parameter = Expression.Parameter(typeof(TEntityBase), "item");
//                var typeIsExpression = Expression.Lambda<Func<TEntityBase, bool>>(Expression.TypeIs(parameter, typeof(TEntity)), parameter);

//                queryable = queryable.Where(typeIsExpression);
//            }

//            foreach (TEntity entity in queryable)
//            {
//                yield return new TModel { Entity = entity };
//            }
//        }

//        public static TModel SingleOrDefault<TContext, TModel, TEntity>(this ModelQueryExtensionPoint<TContext, TModel, TEntity> extensionPoint)
//            where TContext : DataServiceContext
//            where TModel : EntityDataServiceModel<TContext, TEntity>, new()
//            where TEntity : class, new()
//        {
//            return extensionPoint.AsEnumerable().SingleOrDefault();
//        }
//    }
//}
