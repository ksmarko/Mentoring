using System;

namespace Decorator.Calculator
{
    public class Pow : IOperation
    {
        private readonly double _value;
        private readonly double _power;

        public Pow(IOperation value, IOperation power)
        {
            _value = value.Result();
            _power = power.Result();
        }

        public double Result()
        {
            return Math.Pow(_value, _power);
        }
    }
}

