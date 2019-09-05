using ConfigurationProvider.DataProvider;
using ConfigurationProvider.Models;
using ConfigurationProvider.ObjectBuilder;

namespace ConfigurationProvider
{
    public interface IConfigurationProvider
    {
        T GetConfiguration<T>(EnvironmentType env);
    }

    public class ConfigurationProvider : IConfigurationProvider
    {
        private readonly IDataProvider _dataProvider;
        private readonly IObjectBuilder _objectBuilder;

        public ConfigurationProvider(IDataProvider dataProvider, IObjectBuilder objectBuilder)
        {
            _dataProvider = dataProvider;
            _objectBuilder = objectBuilder;
        }

        public T GetConfiguration<T>(EnvironmentType env)
        {
            var objectProperties = _dataProvider.GetProperties(env);
            return _objectBuilder.Build<T>(objectProperties);
        }
    }
}
