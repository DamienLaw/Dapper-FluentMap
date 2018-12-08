using System;
using System.Linq;
using System.Reflection;
using Dommel;
using static Dommel.DommelMapper;

namespace Dapper.FluentMap.Dommel.Resolvers
{
    /// <summary>
    /// Implements the <see cref="IColumnNameResolver"/> interface by using the configured mapping.
    /// </summary>
    public class DommelColumnNameResolver : DefaultColumnNameResolver
    {
        /// <inheritdoc/>
        public override string ResolveColumnName(PropertyInfo propertyInfo)
        {
            if (propertyInfo.DeclaringType != null)
            {
                if (FluentMapper.Configuration.EntityMaps.TryGetValue(propertyInfo.ReflectedType ?? throw new InvalidOperationException(), out var entityMap))
                {
                    var propertyMap = entityMap.PropertyMaps.FirstOrDefault(m => m.PropertyInfo.Name == propertyInfo.Name);
                    if (propertyMap != null)
                    {
                        return propertyMap.ColumnName;
                    }
                }
            }

            return base.ResolveColumnName(propertyInfo);
        }
    }
}
