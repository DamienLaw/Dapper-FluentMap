﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Dapper.FluentMap.Dommel.Mapping;
using static Dommel.DommelMapper;

namespace Dapper.FluentMap.Dommel.Resolvers
{
    /// <inheritdoc />
    /// <summary>
    /// Implements the <see cref="T:Dommel.DommelMapper.IKeyPropertyResolver" /> interface by using the configured mapping.
    /// </summary>
    public class DommelKeyPropertyResolver : DefaultKeyPropertyResolver
    {
        /// <inheritdoc/>
        public override IEnumerable<PropertyInfo> ResolveKeyProperties(Type type)
        {
            if (!FluentMapper.Configuration.EntityMaps.TryGetValue(type, out var entityMap))
            {
                return base.ResolveKeyProperties(type);
            }

            if (entityMap is IDommelEntityMap)
            {
                return entityMap
                    .PropertyMaps
                    .OfType<DommelPropertyMap>()
                    .Where(m => m.Key)
                    .Select(m => m.PropertyInfo)
                    .ToArray();
            }

            // Fall back to the default mapping strategy.
            return base.ResolveKeyProperties(type);
        }
    }
}
