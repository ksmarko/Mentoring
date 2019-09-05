using ConfigurationProvider.DataProvider;
using ConfigurationProvider.Models;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace ConfigurationProvider.Tests.Unit
{
    public class OverrideFilterTests
    {
        private readonly IPropertiesFilter _sut;

        public OverrideFilterTests()
        {
            _sut = new OverrideFilter();
        }

        [Test]
        public void Should_override_properties()
        {
            // Arrange
            var properties = new List<ConfigurationProperty>
            {
                new ConfigurationProperty
                {
                    Namespace = "namespace1",
                    Class = "class1",
                    Property = "property1",
                    Value = "value1"
                },
                null,
                null,
                new ConfigurationProperty
                {
                    Namespace = "namespace1",
                    Class = "class1",
                    Property = "property1",
                    Value = "override_value1"
                },
                new ConfigurationProperty
                {
                    Namespace = "namespace2",
                    Class = "class1",
                    Property = "property1",
                    Value = "value1"
                },
                new ConfigurationProperty
                {
                    Namespace = "namespace3",
                    Class = "class1",
                    Property = "property1",
                    Value = "value1"
                }
            };

            // Act
            var filteredProperties = _sut.Filter(properties).ToList();

            // Assert
            filteredProperties.Should().NotBeNull();
            filteredProperties.Should().BeEquivalentTo(new List<ConfigurationProperty>
            {
                new ConfigurationProperty
                {
                    Namespace = "namespace1",
                    Class = "class1",
                    Property = "property1",
                    Value = "override_value1"
                },
                new ConfigurationProperty
                {
                    Namespace = "namespace2",
                    Class = "class1",
                    Property = "property1",
                    Value = "value1"
                },
                new ConfigurationProperty
                {
                    Namespace = "namespace3",
                    Class = "class1",
                    Property = "property1",
                    Value = "value1"
                }
            });
        }
    }
}
