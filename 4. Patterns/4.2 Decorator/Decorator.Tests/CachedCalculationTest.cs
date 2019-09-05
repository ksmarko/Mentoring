using Decorator.Calculation;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace Decorator.Tests
{
    public class CachedCalculationTest
    {
        private const decimal FirstParameter = 10;
        private const decimal SecondParameter = 15;
        private const decimal ComputedResult = 67600;

        [Test]
        public void Should_add_computed_value_to_cache()
        {
            // Arrange
            var calculationServiceMock = new Mock<ICalculationService>();
            calculationServiceMock.Setup(x => x.Calculate(It.IsAny<decimal>(), It.IsAny<decimal>()))
                .Returns(ComputedResult);
                
            var sut = new CachedCalculationService(calculationServiceMock.Object);

            // Act
            var firstCall = sut.Calculate(FirstParameter, SecondParameter);
            var secondCall = sut.Calculate(FirstParameter, SecondParameter);

            // Assert
            calculationServiceMock.Verify(x => x.Calculate(FirstParameter, SecondParameter), Times.Once);
        }
        
        [Test]
        public void Should_return_correct_result()
        {
            // Arrange
            var sut = new CachedCalculationService(new CalculationService());

            // Act
            var result = sut.Calculate(FirstParameter, SecondParameter);

            // Assert
            result.Should().Be(ComputedResult);
        }
    }
}
