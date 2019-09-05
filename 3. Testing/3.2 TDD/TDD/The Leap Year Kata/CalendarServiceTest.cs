using System;
using FluentAssertions;
using NUnit.Framework;

namespace TDD.The_Leap_Year_Kata
{
    public class CalendarServiceTest
    {
        [Test]
        public void Should_throw_Argument_exception_if_year_is_negative()
        {
            // Arrange
            var sut = new CalendarService();
            
            // Act & Assert
            Assert.Throws<ArgumentException>(() => sut.IsLeapYear(-1));
        }

        [Test]
        public void Should_throw_Argument_exception_if_year_is_equal_to_zero()
        {
            // Arrange
            var sut = new CalendarService();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => sut.IsLeapYear(0));
        }

        [Test]
        [TestCase(1600)]
        [TestCase(2000)]
        [TestCase(2012)]
        [TestCase(2008)]
        public void Should_return_true_if_year_is_leap(int year)
        {
            // Arrange
            var sut = new CalendarService();

            // Act
            var result = sut.IsLeapYear(year);

            // Assert
            result.Should().BeTrue();
        }

        [Test]
        [TestCase(2013)]
        [TestCase(1700)]
        [TestCase(1800)]
        public void Should_return_false_if_year_is_not_leap(int year)
        {
            // Arrange
            var sut = new CalendarService();

            // Act
            var result = sut.IsLeapYear(year);

            // Assert
            result.Should().BeFalse();
        }
    }
}
