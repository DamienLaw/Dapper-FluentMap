using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using static Dommel.DommelMapper;

namespace Dapper.FluentMap.Dommel.Resolvers
{
    /// <inheritdoc />
    /// <summary>
    /// Implements the <see cref="T:Dommel.DommelMapper.IPropertyResolver" /> interface by using the configured mapping.
    /// </summary>
    public class DommelPropertyResolver : DefaultPropertyResolver
    {
        /// <inheritdoc/>
        public override IEnumerable<PropertyInfo> ResolveProperties(Type type)
        {
            if (FluentMapper.Configuration.EntityMaps.TryGetValue(type, out var entityMap))
            {
                foreach (var property in base.ResolveProperties(type))
                {
                    // Determine whether the property should be ignored.
                    var propertyMap = entityMap.PropertyMaps.FirstOrDefault(p => p.PropertyInfo.Name == property.Name);
                    if (propertyMap == null || !propertyMap.Ignored)
                    {
                        yield return property;
                    }
                }
            }
            else
            {
                foreach (var property in base.ResolveProperties(type))
                {
                    yield return property;
                }
            }
        }
    }
}
