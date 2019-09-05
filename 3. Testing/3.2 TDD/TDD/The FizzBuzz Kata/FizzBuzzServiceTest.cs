using System;
using FluentAssertions;
using NUnit.Framework;

namespace TDD.The_FizzBuzz_Kata
{
    public class FizzBuzzServiceTest
    {
        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void Print_should_throw_Argument_exception_if_length_is_less_or_equal_to_zero(int length)
        {
            // Arrange
            var sut = new FizzBuzzService();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => sut.Print(length));
        }

        [Test]
        public void Print_should_print_numbers_from_1_to_100()
        {
            // Arrange
            var sut = new FizzBuzzService();
            var length = 100;

            // Act
            var result = sut.Print(length);

            // Assert
            result.Should().NotBeNull();
            result.Length.Should().Be(length);
        }

        [Test]
        public void Print_should_replace_numbers()
        {
            // Arrange
            var sut = new FizzBuzzService();
            var length = 15;
            var expectedResult = GetResult();

            // Act
            var result = sut.Print(length);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Test]
        [TestCase(3)]
        [TestCase(69)]
        public void GetValue_should_write_Fizz_when_number_is_multiples_of_5(int number)
        {
            // Arrange
            var sut = new FizzBuzzService();

            // Act
            var value = sut.GetValue(number);

            // Assert
            value.Should().Be(FizzBuzzValues.Fizz);
        }

        [Test]
        [TestCase(5)]
        [TestCase(55)]
        [TestCase(100)]
        public void GetValue_should_write_Buzz_when_number_is_multiples_of_5(int number)
        {
            // Arrange
            var sut = new FizzBuzzService();

            // Act
            var value = sut.GetValue(number);

            // Assert
            value.Should().Be(FizzBuzzValues.Buzz);
        }

        [Test]
        [TestCase(15)]
        public void GetValue_should_write_FizzBuzz_when_number_is_multiples_of_5_and_3(int number)
        {
            // Arrange
            var sut = new FizzBuzzService();

            // Act
            var value = sut.GetValue(number);

            // Assert
            value.Should().Be(FizzBuzzValues.FizzBuzz);
        }

        private static string[] GetResult()
        {
            return new []
            {
                "1",
                "2",
                FizzBuzzValues.Fizz,
                "4",
                FizzBuzzValues.Buzz,
                FizzBuzzValues.Fizz,
                "7",
                "8",
                FizzBuzzValues.Fizz,
                FizzBuzzValues.Buzz,
                "11",
                FizzBuzzValues.Fizz,
                "13",
                "14",
                FizzBuzzValues.FizzBuzz
            };
        }
    }
}
