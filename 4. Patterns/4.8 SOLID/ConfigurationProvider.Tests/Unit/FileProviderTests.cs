using ConfigurationProvider.DataProvider;
using ConfigurationProvider.Models;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using Moq;

namespace ConfigurationProvider.Tests.Unit
{
    public class FileProviderTests
    {
        private readonly IDataProvider _sut;
        private const string BasePath = "provider";
        private readonly string _filePath = $"{BasePath}/default.txt";

        public FileProviderTests()
        {
            var hierarchyProviderMock = new Mock<IHierarchyProvider>();
            hierarchyProviderMock.Setup(x => x.GetFiles(It.IsAny<EnvironmentType>()))
                .Returns(new List<string>
                {
                    _filePath
                });

            var fileReaderMock = new Mock<IFileReader>();
            fileReaderMock.Setup(x => x.Read(_filePath))
                .Returns(new List<string>
                {
                    "namespace.class.property = value",
                    "",
                    "namespace.class.otherProperty = otherValue"
                });

            var fileParserMock = new Mock<IFileParser>();
            fileParserMock.Setup(x => x.Parse("namespace.class.property = value"))
                .Returns(new ConfigurationProperty
                {
                    Namespace = "namespace",
                    Class = "class",
                    Property = "property",
                    Value = "value"
                });
            fileParserMock.Setup(x => x.Parse("namespace.class.otherProperty = otherValue"))
                .Returns(new ConfigurationProperty
                {
                    Namespace = "namespace",
                    Class = "class",
                    Property = "otherProperty",
                    Value = "otherValue"
                });
            fileParserMock.Setup(x => x.Parse(""))
                .Returns((ConfigurationProperty) null);

            var propertiesFilterMock = new Mock<IPropertiesFilter>();
            propertiesFilterMock.Setup(x => x.Filter(It.IsAny<IEnumerable<ConfigurationProperty>>()))
                .Returns<IEnumerable<ConfigurationProperty>>((properties) => properties);

            _sut = new FileProvider(hierarchyProviderMock.Object,
                fileReaderMock.Object,
                fileParserMock.Object,
                propertiesFilterMock.Object);
        }

        [SetUp]
        public void Setup()
        {
            Directory.CreateDirectory(BasePath);
            File.Create(_filePath).Close();
        }

        [TearDown]
        public void TearDown()
        {
            if (Directory.Exists(BasePath))
                Directory.Delete(BasePath, true);
        }

        [Test]
        public void Should_get_configuration_properties()
        {
            // Act
            var properties = _sut.GetProperties(EnvironmentType.Development);

            // Assert
            properties.Should().BeEquivalentTo(new List<ConfigurationProperty>
            {
                new ConfigurationProperty
                {
                    Namespace = "namespace",
                    Class = "class",
                    Property = "property",
                    Value = "value"
                },
                new ConfigurationProperty
                {
                    Namespace = "namespace",
                    Class = "class",
                    Property = "otherProperty",
                    Value = "otherValue"
                }
            });
        }
    }
}
