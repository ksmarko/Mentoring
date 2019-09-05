using ConfigurationProvider.Models;
using System;
using System.Collections.Generic;

namespace ConfigurationProvider.ObjectBuilder
{
    public interface IObjectBuilder
    {
        T Build<T>(IEnumerable<ConfigurationProperty> properties);
    }

    public class ObjectBuilder : IObjectBuilder
    {
        public T Build<T>(IEnumerable<ConfigurationProperty> properties)
        {
            var type = typeof(T);
            var instance = Activator.CreateInstance<T>();

            foreach (var property in properties)
            {
                if (property.Namespace != null && !type.FullName.Equals(property.FullName))
                    continue;

                var propertyInfo = type.GetProperty(property.Property);

                if (propertyInfo == null)
                    continue;
                
                propertyInfo.SetValue(instance, Convert.ChangeType(property.Value, propertyInfo.PropertyType));
            }

            return instance;
        }
    }
}
