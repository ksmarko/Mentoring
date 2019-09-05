using System.Collections.Generic;

namespace Adapter
{
    public class Elements<T> : IElements<T>
    {
        private readonly IEnumerable<T> _documents;

        public Elements(IEnumerable<T> documents)
        {
            _documents = documents;
        }

        public IEnumerable<T> GetElements()
        {
            return _documents;
        }
    }
}
