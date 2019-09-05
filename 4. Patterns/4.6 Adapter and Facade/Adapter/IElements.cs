using System.Collections.Generic;

namespace Adapter
{
    // Legacy code
    public interface IElements<T>
    {
        IEnumerable<T> GetElements();
    }
}
