using StockExchange.Common;
using System;

namespace StockExchange.Interfaces
{
    abstract class TradeSubject : IObserver
    {
        protected readonly string Name;
        private readonly IObservable _stockMarket;

        protected TradeSubject(string name, IObservable stockMarket)
        {
            Name = name;
            _stockMarket = stockMarket;
            _stockMarket.Add(this);
        }

        public abstract void Update(StockInfo info);

        public void Quite()
        {
            _stockMarket.Remove(this);
        }
    }

    class Broker : TradeSubject
    {
        public Broker(string name, IObservable stockMarket) : base(name, stockMarket) { }

        public override void Update(StockInfo info)
        {
            Console.WriteLine($"Broker {Name} sells stocks of {info.Company} with price ${info.Price}");
        }
    }

    class Bank : TradeSubject
    {
        public Bank(string name, IObservable stockMarket) : base(name, stockMarket) { }

        public override void Update(StockInfo info)
        {
            Console.WriteLine($"Bank {Name} sells stocks of {info.Company} with price ${info.Price + info.Price * 0.05} (includes 5% commission)");
        }
    }
}
