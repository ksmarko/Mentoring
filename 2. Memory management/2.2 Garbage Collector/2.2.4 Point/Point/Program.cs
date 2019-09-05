using System;

namespace Point
{
    //Reason: struct is a value type and copies by value, so
    //when we use foreach cycle, we work only with collection iterator,
    //that returns copy of the object.
    //Solution #1: use array instead of list
    //Solution #2: using class keyword instead of struct, so now we can manipulate objects by its references (not copies)

    //Solution #1
    class Program
    {
        static void Main()
        {
            var points = new Point[10];

            for (int i = 0; i < points.Length; i++)
            {
                points[i].IncX();
            }

            foreach (var p in points)
            {
                Console.WriteLine(p.X);
            }

            Console.ReadKey();
        }
    }

    public struct Point
    {
        public int X;

        public void IncX()
        {
            X++;
        }
    }

    //Solution #2
    //class Program
    //{
    //    static void Main()
    //    {
    //        var points = new List<Point>(Enumerable.Range(1, 10).Select(p => new Point()));

    //        foreach (var p in points)
    //            p.IncX();

    //        foreach (var p in points)
    //            Console.WriteLine(p.X);

    //        Console.ReadKey();
    //    }
    //}

    //public class Point
    //{
    //    public int X;

    //    public void IncX()
    //    {
    //        X++;
    //    }
    //}
}
