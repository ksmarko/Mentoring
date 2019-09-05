namespace Decorator.Calculator
{
    public class Sqr : IOperation
    {
        private readonly double _value;

        public Sqr(IOperation value)
        {
            _value = value.Result();
        }

        public double Result()
        {
            return new Pow(new Const(_value), new Const(2)).Result();
        }
    }
}
