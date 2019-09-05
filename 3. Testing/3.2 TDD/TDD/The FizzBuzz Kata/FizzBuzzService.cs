using System;

namespace TDD.The_FizzBuzz_Kata
{
    public class FizzBuzzService
    {
        public string[] Print(int length)
        {
            if(length <= 0)
                throw new ArgumentException("Value should be positive.", nameof(length));

            var array = new string[length];

            for (int i = 0; i < length; i++)
            {
                array[i] = GetValue(i + 1);
            }

            return array;
        }

        public string GetValue(int number)
        {
            if (number % 3 == 0 && number % 5 == 0)
                return FizzBuzzValues.FizzBuzz;

            if (number % 3 == 0)
                return FizzBuzzValues.Fizz;

            if (number % 5 == 0)
                return FizzBuzzValues.Buzz;

            return number.ToString();
        }
    }
}
