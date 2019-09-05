using Factory.Models;
using System.Collections.Generic;
using System.Linq;

namespace Factory.Filters
{
    public class BarclaysFilter : IFilter
    {
        private const int Amount = 50;

        public IEnumerable<Trade> Match(IEnumerable<Trade> trades)
        {
            return trades.Where(trade => trade.Type == TradeType.Option
                                         && trade.SubType == TradeSubType.NyOption
                                         && trade.Amount > Amount);
        }
    }
}
