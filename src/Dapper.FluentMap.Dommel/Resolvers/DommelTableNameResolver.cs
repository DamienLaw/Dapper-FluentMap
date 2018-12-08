using System;
using Dapper.FluentMap.Dommel.Mapping;
using static Dommel.DommelMapper;

namespace Dapper.FluentMap.Dommel.Resolvers
{
    /// <inheritdoc />
    /// <summary>
    /// Implements the <see cref="T:Dommel.DommelMapper.ITableNameResolver" /> interface by using the configured mapping.
    /// </summary>
    public class DommelTableNameResolver : DefaultTableNameResolver
    {
        /// <inheritdoc />
        public override string ResolveTableName(Type type)
        {
            if (FluentMapper.Configuration.EntityMaps.TryGetValue(type, out var entityMap) &&
                entityMap is IDommelEntityMap mapping)
            {
                return mapping.TableName;
            }

            return base.ResolveTableName(type);
        }
    }
}
