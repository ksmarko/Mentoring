using StockExchange.Common;

namespace StockExchange.Interfaces
{
    interface IObserver
    {
        void Update(StockInfo info);
    }
}
