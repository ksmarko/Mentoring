using System;

namespace Resurrection
{
    class SomeClass
    {
        public static Object objectHolder;
        private static int _counter;
        public int ResurrectionCount { get; private set; }
        public int Id { get; }

        public SomeClass()
        {
            Random random = new Random();

            var x = new double[random.Next(1, 100) * 100];
            Id = _counter++;

            Print($"Constructor for #{Id}", ConsoleColor.Green);
        }

        ~SomeClass()
        {
            Print($"Destructor for #{Id}", ConsoleColor.Red);

            objectHolder = this;
            ResurrectionCount++;
            GC.ReRegisterForFinalize(this);
        }

        private void Print(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
