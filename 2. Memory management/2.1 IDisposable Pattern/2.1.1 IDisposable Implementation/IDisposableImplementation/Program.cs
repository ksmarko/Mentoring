using System;

namespace NetMentoring
{
    class Program
    {
        private static void Main(string[] args)
        {
            using (var logger = new MemoryStreamLogger())
            {
                for (var i = 0; i < 10000; i++)
                    logger.Log($"Iteration number #{i}");
            }

            Console.WriteLine("Finished");
            Console.ReadKey();
        }
    }
}
