namespace Decorator.Calculator
{
    public class Mul : IOperation
    {
        private readonly double _leftOperand;
        private readonly double _rightOperand;

        public Mul(IOperation left, IOperation right)
        {
            _leftOperand = left.Result();
            _rightOperand = right.Result();
        }

        public double Result()
        {
            return _leftOperand * _rightOperand;
        }
    }
}

