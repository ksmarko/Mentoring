using Factory.Models;
using System.Collections.Generic;
using System.Linq;

namespace Factory.Filters
{
    public class ConnacordFilter : IFilter
    {
        private const int From = 10;
        private const int To = 40;

        public IEnumerable<Trade> Match(IEnumerable<Trade> trades)
        {
            return trades.Where(trade => trade.Type == TradeType.Future && trade.Amount > From && trade.Amount < To);
        }
    }
}
