using System;

namespace TDD.The_Leap_Year_Kata
{
    public class CalendarService
    {
        public bool IsLeapYear(int year)
        {
            if (year <= 0)
                throw new ArgumentException("Value should be positive.", nameof(year));

            return (year % 4 == 0 && year % 100 != 0) || year % 400 == 0;
        }
    }
}
