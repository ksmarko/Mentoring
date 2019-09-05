using ConfigurationProvider.DataProvider;
using ConfigurationProvider.Models;
using FluentAssertions;
using NUnit.Framework;

namespace ConfigurationProvider.Tests.Unit
{
    public class EnvironmentFactoryTests
    {
        private readonly IEnvironmentFactory _sut;

        public EnvironmentFactoryTests()
        {
            _sut = new EnvironmentFactory();
        }

        [Test]
        [TestCase(EnvironmentType.Development, "dev")]
        [TestCase(EnvironmentType.Uat, "uat")]
        [TestCase(EnvironmentType.Production, "prod")]
        public void Should_return_correct_file_name_part_for_env(EnvironmentType env, string expectedName)
        {
            // Act
            var name = _sut.GetFileNamePattern(env);

            // Assert
            name.Should().Be(expectedName);
        }
    }
}
