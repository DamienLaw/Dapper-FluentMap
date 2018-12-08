using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Dapper.FluentMap.Dommel.Mapping;
using static Dommel.DommelMapper;

namespace Dapper.FluentMap.Dommel.Resolvers
{
    /// <inheritdoc />
    /// <summary>
    /// Implements the <see cref="T:Dommel.DommelMapper.IIdentityPropertyResolver" /> interface by using the configured mapping.
    /// </summary>
    public class DommelIdentityPropertyResolver : DefaultIdentityPropertyResolver
    {
        /// <inheritdoc/>
        public override IEnumerable<PropertyInfo> ResolveIdentityProperties(Type type)
        {
            if (!FluentMapper.Configuration.EntityMaps.TryGetValue(type, out var entityMap))
            {
                return base.ResolveIdentityProperties(type);
            }

            if (entityMap is IDommelEntityMap)
            {
                return entityMap
                    .PropertyMaps
                    .OfType<DommelPropertyMap>()
                    .Where(m => m.Identity)
                    .Select(m => m.PropertyInfo)
                    .ToArray();
            }

            // Fall back to the default mapping strategy.
            return base.ResolveIdentityProperties(type);
        }
    }
}