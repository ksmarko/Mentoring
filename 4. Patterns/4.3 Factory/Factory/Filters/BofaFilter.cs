using System.Collections.Generic;
using System.Linq;
using Factory.Models;

namespace Factory.Filters
{
    public class BofaFilter : IFilter
    {
        private const int Amount = 70;

        public IEnumerable<Trade> Match(IEnumerable<Trade> trades) => trades.Where(trade => trade.Amount > Amount);
    }
}
