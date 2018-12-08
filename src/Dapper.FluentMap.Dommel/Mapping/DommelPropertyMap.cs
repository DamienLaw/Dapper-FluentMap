using System.Reflection;
using Dapper.FluentMap.Mapping;

namespace Dapper.FluentMap.Dommel.Mapping
{
    /// <summary>
    /// A Dommel <see cref="PropertyMap"/>.
    /// </summary>
    public class DommelPropertyMap : PropertyMap
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DommelPropertyMap"/> class.
        /// </summary>
        /// <param name="propertyInfo">The property info to apply the mapping to.</param>
        public DommelPropertyMap(PropertyInfo propertyInfo) : base(propertyInfo)
        {
        }

        /// <summary>
        /// Gets or sets a value indicating whether the current property is considered a key property.
        /// </summary>
        public bool Key { get; private set; }

        /// <summary>
        /// Gets a value indicating whether this primary key is an identity.
        /// </summary>
        public bool Identity { get; private set; }

        /// <summary>
        /// Marks the property as a key property.
        /// </summary>
        public DommelPropertyMap IsKey()
        {
            Key = true;
            return this;
        }

        /// <summary>
        /// Specifies the current property as an identity.
        /// </summary>
        /// <returns>The current instance of <see cref="DommelPropertyMap"/>.</returns>
        public DommelPropertyMap IsIdentity()
        {
            Identity = true;
            return this;
        }
    }

    /// <summary>
    /// Dommel extensions for <see cref="PropertyMap"/>.
    /// </summary>
    public static class PropertyMapExtensions
    {
        /// <summary>
        /// Marks the property as a key property.
        /// </summary>
        public static PropertyMap IsKey(this PropertyMap propertyMapping)
        {
            if (propertyMapping is DommelPropertyMap dommelPropertyMapping)
            {
                dommelPropertyMapping.IsKey();
            }

            return propertyMapping;
        }

        /// <summary>
        /// Marks the property as an identity property.
        /// </summary>
        public static PropertyMap IsIdentity(this PropertyMap propertyMapping)
        {
            if (propertyMapping is DommelPropertyMap dommelPropertyMapping)
            {
                dommelPropertyMapping.IsIdentity();
            }

            return propertyMapping;
        }
    }
}
