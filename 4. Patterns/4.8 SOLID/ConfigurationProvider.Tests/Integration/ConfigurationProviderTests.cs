using System.IO;
using ConfigurationProvider.DataProvider;
using ConfigurationProvider.Models;
using FluentAssertions;
using NUnit.Framework;

namespace ConfigurationProvider.Tests.Integration
{
    public class ConfigurationProviderTests
    {
        private readonly IConfigurationProvider _sut;
        private const string BasePath = "integration";

        public ConfigurationProviderTests()
        {
            var fileProviderOptions = new FileProviderOptions
            {
                BasePath = BasePath
            };
            var environmentFactory = new EnvironmentFactory();
            var hierarchyProvider = new HierarchyProvider(fileProviderOptions, environmentFactory);
            var fileReader = new FileReader();
            var fileParser = new FileParser();
            var propertiesFilter = new OverrideFilter();
            var fileProvider = new FileProvider(hierarchyProvider, fileReader, fileParser, propertiesFilter);
            var objectBuilder = new ObjectBuilder.ObjectBuilder();

            _sut = new ConfigurationProvider(fileProvider, objectBuilder);
        }

        [OneTimeSetUp]
        public void SetUp()
        {
            Directory.CreateDirectory(BasePath);

            var defaultFileContent = new []
            {
                "# service settings",
                "ConfigurationProvider.Tests.Integration.ServiceSettings.ConnectionString = (localhost)/mssql #TODO: use mysql",
                "ConfigurationProvider.Tests.Unit.ServiceSettings.ConnectionString = (localhost)/mysql",
                "ServiceSettings.EnableLogging = true",
                "QueueSettings.Url = fake.queue",
                "",
                "# parsing settings",
                "ParsingSettings.Override = true"
            };

            var devFileContent = new[]
            {
                "ConfigurationProvider.Tests.Integration.ServiceSettings.Port = 5600",
                "ServiceSettings.EnableLogging = false",
                "# parsing settings",
                "ParsingSettings.Path = Configuration/Parser/",
                "ParsingSettings.Port = 1200",
                "ParsingSettings.Override = true"
            };

            File.WriteAllLines($"{BasePath}/default.txt", defaultFileContent);
            File.WriteAllLines($"{BasePath}/dev.txt", devFileContent);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            if (Directory.Exists(BasePath))
                Directory.Delete(BasePath, true);
        }

        [Test]
        public void Should_get_ServiceSettings_for_dev()
        {
            // Act
            var config = _sut.GetConfiguration<ServiceSettings>(EnvironmentType.Development);

            // Assert
            config.Should().NotBeNull();
            config.ConnectionString.Should().Be("(localhost)/mssql");
            config.Port.Should().Be(5600);
            config.EnableLogging.Should().BeFalse();
        }
    }
}
