using System;
using System.Collections.Generic;

namespace Resurrection_WithoutGlobalVariables
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
            var list = new List<WeakReference>();

            while (counter++ < 5000)
            {
                var x = new SomeClass();
                WeakReference wr = new WeakReference(x, true);
                list.Add(wr);
            }
            
            // without it finalizers will run after list of resurrections
            GC.WaitForPendingFinalizers();
            
            foreach (var el in list)
            {
                Console.WriteLine(el.Target == null ? "NULL" : $"Object #{(el.Target as SomeClass).Id}. Resurrections: {(el.Target as SomeClass).ResurrectionCount}");
            }
                       
            Console.ReadKey();
        }
    }
}
