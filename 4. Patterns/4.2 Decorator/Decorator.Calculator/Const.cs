namespace Decorator.Calculator
{
    public class Const : IOperation
    {
        private readonly double _value;

        public Const(double value)
        {
            _value = value;
        }

        public double Result()
        {
            return _value;
        }
    }
}
