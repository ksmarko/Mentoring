using AutoFixture;
using System;

namespace Adapter.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var printer = new Printer();
            var printerAdapter = new PrinterAdapter();
            var fixture = new Fixture();
            var documents = fixture.CreateMany<Document>(10);
            var container = new Container<Document>(documents);

            // Legacy Printer writes data about items itself
            Console.WriteLine("Original printer:");
            printer.Print(container);

            // Custom Printer returns these objects,
            // so for representation purposes let's print them
            Console.WriteLine("\n\nCustom printer:");
            var printedElements = printerAdapter.Print(container);

            foreach (var el in printedElements)
            {
                Console.WriteLine($"\n\nName: {el.Name}\nContent: {el.Content}\nSize: {el.Size}");
            }

            Console.ReadKey();
        }
    }
}
