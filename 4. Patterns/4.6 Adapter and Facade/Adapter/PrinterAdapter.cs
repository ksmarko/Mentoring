using System.Collections.Generic;

namespace Adapter
{
    public class PrinterAdapter : Printer
    {
        public new IEnumerable<T> Print<T>(IContainer<T> container)
        {
            var elements = new Elements<T>(container.Items);
            return elements.GetElements();
        }
    }
}
