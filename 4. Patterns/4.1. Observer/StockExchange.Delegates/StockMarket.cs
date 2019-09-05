using StockExchange.Common;
using System;

namespace StockExchange.Delegates
{
    class StockMarket
    {
        public delegate void StockMarketStateHandler(StockInfo info);
        private StockMarketStateHandler _handler;

        public void RegisterHandler(StockMarketStateHandler handler)
        {
            _handler += handler;
        }

        public void UnRegisterHandler(StockMarketStateHandler handler)
        {
            _handler -= handler;
        }

        public void StartTrade()
        {
            var info = StockGenerator.GenerateInfo();
            WriteMessage($"\nCompany: {info.Company}, Price: {info.Price}");

            _handler?.Invoke(info);
        }

        private void WriteMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
