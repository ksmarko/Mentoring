using StockExchange.Common;
using System;

namespace StockExchange.Delegates
{
    abstract class TradeSubject
    {
        protected readonly string Name;
        private readonly StockMarket _stockMarket;

        protected TradeSubject(string name, StockMarket stockMarket)
        {
            Name = name;
            _stockMarket = stockMarket;
            stockMarket.RegisterHandler(Update);
        }

        public abstract void Update(StockInfo info);

        public void Quite()
        {
            _stockMarket.UnRegisterHandler(Update);
        }
    }

    class Broker : TradeSubject
    {
        public Broker(string name, StockMarket stockMarket) : base(name, stockMarket) { }

        public override void Update(StockInfo info)
        {
            Console.WriteLine($"Broker {Name} sells stocks of {info.Company} with price ${info.Price}");
        }
    }

    class Bank : TradeSubject
    {
        public Bank(string name, StockMarket stockMarket) : base(name, stockMarket) { }

        public override void Update(StockInfo info)
        {
            Console.WriteLine($"Bank {Name} sells stocks of {info.Company} with price ${info.Price + info.Price * 0.05} (includes 5% commission)");
        }
    }
}
