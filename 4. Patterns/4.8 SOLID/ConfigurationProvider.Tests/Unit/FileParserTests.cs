using System;
using ConfigurationProvider.DataProvider;
using ConfigurationProvider.Exceptions;
using FluentAssertions;
using NUnit.Framework;

namespace ConfigurationProvider.Tests.Unit
{
    public class FileParserTests
    {
        private readonly IFileParser _sut;

        public FileParserTests()
        {
            _sut = new FileParser();
        }

        [Test]
        [TestCase("namespace.subnamespace.class.property = value")]
        [TestCase("namespace.subnamespace.class.property = value #because this is comment")]
        public void Should_parse_line(string line)
        {
            // Act
            var property = _sut.Parse(line);

            // Assert
            property.Namespace.Should().Be("namespace.subnamespace");
            property.Class.Should().Be("class");
            property.Property.Should().Be("property");
            property.Value.Should().Be("value");
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void Should_return_null_if_line_is_null_or_empty(string line)
        {
            // Act
            var parsedLine = _sut.Parse(line);

            // Assert
            parsedLine.Should().BeNull();
        }

        [Test]
        [TestCase("namespace.class.property = value = value")]
        [TestCase("namespace.class.property == value")]
        [TestCase("namespace.class = property = value")]
        [TestCase("class #property = value")]
        public void Should_throw_LineParsingException_if_line_has_incorrect_format(string line)
        {
            // Arrange
            Action action = () => _sut.Parse(line);

            // Act & Assert
            action.Should().Throw<LineParsingException>()
                .WithMessage("Property definition must be in format {namespace (optional)}.{class}.{property} = {value}");
        }

        [Test]
        [TestCase("namespace.class.property   = value")]
        [TestCase("namespace.class. property = value")]
        [TestCase("namespace.class class. property = value")]
        [TestCase("namespace.class.!property = value")]
        [TestCase("namespace.class.1property = value")]
        public void Should_throw_NameValidationException_if_line_has_incorrect_characters(string line)
        {
            // Arrange
            Action action = () => _sut.Parse(line);

            // Act & Assert
            action.Should().Throw<NameValidationException>();
        }

        [Test]
        [TestCase("namespace.class._property = value")]
        [TestCase("namespace.class.property_ = value")]
        [TestCase("namespace.class_class.property = value")]
        [TestCase("namespace.class.property = value")]
        [TestCase("namespace.class.property! = value")]
        public void Should_not_throw_NameValidationException_if_line_has_correct_characters(string line)
        {
            // Arrange
            Action action = () => _sut.Parse(line);

            // Act & Assert
            action.Should().NotThrow<NameValidationException>();
        }
    }
}
