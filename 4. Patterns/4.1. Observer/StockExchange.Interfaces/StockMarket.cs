using System;
using StockExchange.Common;
using System.Collections.Generic;

namespace StockExchange.Interfaces
{
    class StockMarket : IObservable
    {
        private readonly List<IObserver> _observers;

        public StockMarket()
        {
            _observers = new List<IObserver>();
        }

        public void StartTrade()
        {
            var info = StockGenerator.GenerateInfo();
            WriteMessage($"\nCompany: {info.Company}, Price: {info.Price}");
            Notify(info);
        }

        public void Add(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Remove(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify(StockInfo info)
        {
            _observers.ForEach(x => x.Update(info));
        }

        private void WriteMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
