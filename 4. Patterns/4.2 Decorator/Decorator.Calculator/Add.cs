namespace Decorator.Calculator
{
    public class Add : IOperation
    {
        private readonly double _leftOperand;
        private readonly double _rightOperand;

        public Add(IOperation left, IOperation right)
        {
            _leftOperand = left.Result();
            _rightOperand = right.Result();
        }

        public double Result()
        {
            return _leftOperand + _rightOperand;
        }
    }
}
