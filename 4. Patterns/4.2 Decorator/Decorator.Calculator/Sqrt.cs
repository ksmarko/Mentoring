using System;

namespace Decorator.Calculator
{
    public class Sqrt : IOperation
    {
        private readonly double _value;

        public Sqrt(IOperation value)
        {
            _value = value.Result();
        }
        
        public double Result()
        {
            return Math.Sqrt(_value);
        }
    }
}
