using StockExchange.Common;

namespace StockExchange.Interfaces
{
    interface IObservable
    {
        void Add(IObserver observer);
        void Remove(IObserver observer);
        void Notify(StockInfo info);
    }
}
