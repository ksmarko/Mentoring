using System;
using FluentAssertions;
using NUnit.Framework;

namespace TDD.The_Calc_Stats_Kata
{
    public class CalculatorServiceTests
    {
        [Test]
        [TestCase(null)]
        [TestCase(new int[0])]
        public void Should_throw_argument_exception_if_numbers_sequence_is_null_or_empty(int[] numbers)
        {
            // Arrange
            var sut = new CalculatorServcie();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => sut.GetStatistics(numbers));
        }

        [Test]
        [TestCase(new [] {4, 2, -1, 13}, -1)]
        [TestCase(new [] {0, 11, -5, -2, 7}, -5)]
        [TestCase(new [] {1, 1, 1, 1, 1}, 1)]
        public void Should_return_correct_min_value(int[] numbers, int expectedResult)
        {
            // Arrange
            var sut = new CalculatorServcie();

            // Act
            var statistics = sut.GetStatistics(numbers);

            // Assert
            statistics.Should().NotBeNull();
            statistics.MinValue.Should().Be(expectedResult);
        }

        [Test]
        [TestCase(new[] { 4, 2, -1, 13 }, 13)]
        [TestCase(new[] { 0, 11, -5, -2, 7 }, 11)]
        [TestCase(new[] { 1, 1, 1, 1, 1 }, 1)]
        public void Should_return_correct_max_value(int[] numbers, int expectedResult)
        {
            // Arrange
            var sut = new CalculatorServcie();

            // Act
            var statistics = sut.GetStatistics(numbers);

            // Assert
            statistics.Should().NotBeNull();
            statistics.MaxValue.Should().Be(expectedResult);
        }

        [Test]
        [TestCase(new[] { 4, 2, -1, 13 }, 4.5)]
        [TestCase(new[] { 0, 11, -5, -2, 8 }, 2.4)]
        [TestCase(new[] { 1, 1, 1, 1, 1 }, 1)]
        public void Should_return_correct_average_value(int[] numbers, double expectedResult)
        {
            // Arrange
            var sut = new CalculatorServcie();

            // Act
            var statistics = sut.GetStatistics(numbers);

            // Assert
            statistics.Should().NotBeNull();
            statistics.AverageValue.Should().Be(expectedResult);
        }

        [Test]
        [TestCase(new[] { 0 }, 1)]
        [TestCase(new[] { 1, 1, 1, 1, 1 }, 5)]
        public void Should_return_correct_elements_count(int[] numbers, int expectedResult)
        {
            // Arrange
            var sut = new CalculatorServcie();

            // Act
            var statistics = sut.GetStatistics(numbers);

            // Assert
            statistics.Should().NotBeNull();
            statistics.ElementsCount.Should().Be(expectedResult);
        }
    }
}
