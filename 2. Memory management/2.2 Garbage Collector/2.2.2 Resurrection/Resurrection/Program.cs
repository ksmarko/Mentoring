using System;
using System.Collections.Generic;

namespace Resurrection
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
            var list = new List<WeakReference>();

            while(counter++ < 5000)
            {
                var x = new SomeClass();
                WeakReference wr = new WeakReference(x, true);
                list.Add(wr);
            }

            Console.ReadKey();

            //As all objects are resurrected and we have access to their fields, 
            //so we can print object id and count of resurrections
            foreach (var el in list)
            {
                Console.WriteLine(el.Target == null ? "NULL" : $"Object #{(el.Target as SomeClass).Id}. Resurrections: {(el.Target as SomeClass).ResurrectionCount}");
            }

            Console.ReadKey();
        }
    }
}
