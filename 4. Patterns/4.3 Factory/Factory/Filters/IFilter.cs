using Factory.Models;
using System.Collections.Generic;

namespace Factory.Filters
{
    public interface IFilter
    {
        IEnumerable<Trade> Match(IEnumerable<Trade> trades);
    }
}
