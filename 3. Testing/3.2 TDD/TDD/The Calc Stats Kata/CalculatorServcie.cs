using System;
using System.Linq;

namespace TDD.The_Calc_Stats_Kata
{
    public class CalculatorServcie
    {
        public NumberStatistics GetStatistics(params int[] numbers)
        {
            if (numbers == null || !numbers.Any())
                throw new ArgumentException("Value cannot be null or empty.", nameof(numbers));

            return new NumberStatistics()
            {
                MinValue = numbers.Min(),
                MaxValue = numbers.Max(),
                AverageValue = numbers.Average(),
                ElementsCount = numbers.Length
            };
        }
    }
}
