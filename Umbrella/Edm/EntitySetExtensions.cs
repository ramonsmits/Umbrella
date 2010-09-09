using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nVentive.Umbrella.Extensions;

namespace nVentive.Umbrella.Edm
{
    public static class EntitySetExtensions
    {
        public static string GetEntitySetName(object entity)
        {
            return GetEntitySetName(entity.GetType());
        }

        public static string GetEntitySetName(Type entityType)
        {
            var attribute = entityType.FindAttribute<EntitySetAttribute>();

            return attribute == null ? entityType.Name : attribute.Name;
        }
    }
}
