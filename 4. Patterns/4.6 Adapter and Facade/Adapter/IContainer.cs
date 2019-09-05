using System.Collections.Generic;
using System.Linq;

namespace Adapter
{
    // Legacy code
    public interface IContainer<T>
    {
        IEnumerable<T> Items { get; }
        int Count { get; }
    }

    public class Container<T> : IContainer<T>
    {
        public IEnumerable<T> Items { get; }
        public int Count { get; }

        public Container(IEnumerable<T> items)
        {
            Items = items;
            Count = items.Count();
        }
    }
}
