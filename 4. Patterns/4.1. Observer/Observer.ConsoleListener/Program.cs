using System;

namespace Observer.ConsoleListener
{
    class Program
    {
        static void Main(string[] args)
        {
            var listener = new ConsoleListener();

            while (true)
            {
                listener.Listen(Console.ReadLine());
            }
        }
    }

    class ConsoleListener
    {
        public void Listen(string message)
        {
            if (message.Equals("quit"))
                Environment.Exit(0);
        }
    }
}
