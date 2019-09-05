using System;

namespace Decorator.Calculator
{
    public class Div : IOperation
    {
        private readonly double _leftOperand;
        private readonly double _rightOperand;

        public Div(IOperation left, IOperation right)
        {
            if (right.Result().Equals(0))
                throw new ArgumentException("Value cannot be 0", nameof(right));

            _leftOperand = left.Result();
            _rightOperand = right.Result();
        }

        public double Result()
        {
            return _leftOperand / _rightOperand;
        }
    }
}
