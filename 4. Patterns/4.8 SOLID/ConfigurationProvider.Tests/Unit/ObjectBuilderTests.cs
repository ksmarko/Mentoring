using ConfigurationProvider.Models;
using ConfigurationProvider.ObjectBuilder;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace ConfigurationProvider.Tests.Unit
{
    public class ObjectBuilderTests
    {
        private readonly IObjectBuilder _sut;

        public ObjectBuilderTests()
        {
            _sut = new ObjectBuilder.ObjectBuilder();
        }

        [Test]
        public void Should_build_object_from_properties()
        {
            // Arrange
            var properties = new List<ConfigurationProperty>
            {
                new ConfigurationProperty
                {
                    Namespace = "ConfigurationProvider.Tests.Unit",
                    Class = "TestConfigurationObject",
                    Property = "Path",
                    Value = "x/y/z"
                },
                new ConfigurationProperty
                {
                    Namespace = "ConfigurationProvider.Tests.Unit",
                    Class = "TestConfigurationObject",
                    Property = "IsTest",
                    Value = "true"
                },
                new ConfigurationProperty
                {
                    Namespace = "ConfigurationProvider.Tests.Unit",
                    Class = "TestConfigurationObject",
                    Property = "Port",
                    Value = "11"
                },
                new ConfigurationProperty
                {
                    Namespace = "Configuration.Provider.Tests.Unit",
                    Class = "TestConfigurationObject",
                    Property = "Path",
                    Value = "x/y/z"
                }
            };

            // Act
            var config = _sut.Build<TestConfigurationObject>(properties);

            // Assert
            config.Should().NotBeNull();
            config.Path.Should().Be("x/y/z");
            config.IsTest.Should().BeTrue();
            config.Port.Should().Be(11);
        }

        [Test]
        public void Should_ignore_if_type_does_not_contain_property()
        {
            // Arrange
            var properties = new List<ConfigurationProperty>
            {
                new ConfigurationProperty
                {
                    Namespace = "ConfigurationProvider.Tests.Unit",
                    Class = "TestConfigurationObject",
                    Property = "NonExistingProperty",
                    Value = "x/y/z"
                },
                new ConfigurationProperty
                {
                    Namespace = "ConfigurationProvider.Tests.Unit",
                    Class = "TestConfigurationObject",
                    Property = "IsTest",
                    Value = "true"
                }
            };

            // Act
            var config = _sut.Build<TestConfigurationObject>(properties);

            // Assert
            config.Should().NotBeNull();
            config.Path.Should().BeNull();
            config.IsTest.Should().BeTrue();
            config.Port.Should().Be(0);
        }

        [Test]
        public void Should_initialize_by_default_if_there_are_no_values()
        {
            // Arrange
            var properties = new List<ConfigurationProperty>();

            // Act
            var config = _sut.Build<TestConfigurationObject>(properties);

            // Assert
            config.Should().NotBeNull();
            config.Path.Should().BeNull();
            config.IsTest.Should().BeFalse();
            config.Port.Should().Be(0);
        }
    }

    internal class TestConfigurationObject
    {
        public string Path { get; set; }
        public bool IsTest { get; set; }
        public int Port { get; set; }
    }
}
