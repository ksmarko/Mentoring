using System;
using System.Collections.Generic;
using System.IO;
using ConfigurationProvider.DataProvider;
using ConfigurationProvider.Exceptions;
using ConfigurationProvider.Models;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace ConfigurationProvider.Tests.Unit
{
    public class HierarchyProviderTests
    {
        private const string BasePath = "unit";
        private readonly IHierarchyProvider _sut;

        public HierarchyProviderTests()
        {
            var environmentFactoryMock = new Mock<IEnvironmentFactory>();
            environmentFactoryMock.Setup(x => x.GetFileNamePattern(EnvironmentType.Development))
                .Returns("dev");

            var options = new FileProviderOptions
            {
                BasePath = BasePath
            };

            _sut = new HierarchyProvider(options, environmentFactoryMock.Object);
        }

        [SetUp]
        public void SetUp()
        {
            Directory.CreateDirectory(BasePath);
        }

        [TearDown]
        public void TearDown()
        {
            if (Directory.Exists(BasePath))
                Directory.Delete(BasePath, true);
        }

        [Test]
        public void Should_get_files_by_env_type()
        {
            // Arrange
            File.Create($"{BasePath}/default.txt").Close();
            File.Create($"{BasePath}/dev.txt").Close();
            File.Create($"{BasePath}/dev-NY.txt").Close();
            File.Create($"{BasePath}/dev-NY-1.txt").Close();
            File.Create($"{BasePath}/uat.txt").Close();
            File.Create($"{BasePath}/prod.txt").Close();
            File.Create($"{BasePath}/prod-NY-1.txt").Close();

            // Act
            var files = _sut.GetFiles(EnvironmentType.Development);

            // Assert
            files.Should().ContainInOrder(new List<string>
            {
                $@"{BasePath}\default.txt",
                $@"{BasePath}\dev.txt",
                $@"{BasePath}\dev-NY.txt",
                $@"{BasePath}\dev-NY-1.txt"
            });
        }

        [Test]
        public void Should_throw_ConfigurationProviderException_if_default_file_does_not_exist()
        {
            // Arrange
            Action action = () => _sut.GetFiles(EnvironmentType.Development);

            // Act & Assert
            action.Should().Throw<ConfigurationProviderException>()
                .WithMessage("At least one defauult configuration file must be specified");
        }
    }
}
