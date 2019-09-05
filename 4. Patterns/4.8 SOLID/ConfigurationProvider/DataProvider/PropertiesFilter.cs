using ConfigurationProvider.Models;
using System.Collections.Generic;
using System.Linq;

namespace ConfigurationProvider.DataProvider
{
    public interface IPropertiesFilter
    {
        IEnumerable<ConfigurationProperty> Filter(IEnumerable<ConfigurationProperty> properties);
    }

    public class OverrideFilter : IPropertiesFilter
    {
        public IEnumerable<ConfigurationProperty> Filter(IEnumerable<ConfigurationProperty> properties)
        {
            return properties
                .Where(x => x != null)
                .GroupBy(p => new
                {
                    p.Namespace,
                    p.Class,
                    p.Property
                })
                .Select(grp => new ConfigurationProperty
                {
                    Namespace = grp.Key.Namespace,
                    Class = grp.Key.Class,
                    Property = grp.Key.Property,
                    Value = grp.Last().Value
                })
                .Distinct();
        }
    }
}
