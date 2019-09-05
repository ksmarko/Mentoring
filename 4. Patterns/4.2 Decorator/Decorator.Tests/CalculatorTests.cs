using System;
using Decorator.Calculator;
using FluentAssertions;
using NUnit.Framework;

namespace Decorator.Tests
{
    public class CalculatorTests
    {
        [Test]
        public void Add_should_return_correct_result()
        {
            // 1 + 2
            var result = 
                new Add(
                    new Const(1), 
                    new Const(2))
               .Result();

            result.Should().Be(3);
        }

        [Test]
        public void Const_should_initial_value()
        {
            var result =
                new Const(4)
                .Result();

            result.Should().Be(4);
        }

        [Test]
        public void Div_should_return_correct_result()
        {
            // 27 / 9
            var result =
                new Div(
                        new Const(27),
                        new Const(9))
                    .Result();

            result.Should().Be(3);
        }

        [Test]
        public void DivTest_Shoul_throw_Argument_exception_if_right_operand_is_equal_to_0()
        {
            var message = Assert.Throws<ArgumentException>(() => 
                new Div(
                    new Const(27), 
                    new Const(0))
                .Result());

            message.Message.Should().Contain("Value cannot be 0");
        }

        [Test]
        public void Mul_should_return_correct_result()
        {
            // 3 / 9
            var result =
                new Mul(
                        new Const(3),
                        new Const(9))
                    .Result();

            result.Should().Be(27);
        }

        [Test]
        public void Pow_should_return_correct_result()
        {
            // 3 ^ 3
            var result =
                new Pow(
                        new Const(3),
                        new Const(3))
                    .Result();

            result.Should().Be(27);
        }

        [Test]
        public void Sqr_should_return_correct_result()
        {
            // 8 ^ 2
            var result =
                new Sqr(
                        new Const(8))
                    .Result();

            result.Should().Be(64);
        }

        [Test]
        public void Sqrt_should_return_correct_result()
        {
            // sqrt(4)
            var result = 
                new Sqrt(
                    new Const(4))
               .Result();

            result.Should().Be(2);
        }

        [Test]
        public void Substr_should_return_correct_result()
        {
            // 10 - 9
            var result =
                new Substr(
                        new Const(10),
                        new Const(9))
                    .Result();

            result.Should().Be(1);
        }
    }
}
