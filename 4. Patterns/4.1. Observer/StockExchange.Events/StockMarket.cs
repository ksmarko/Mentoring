using StockExchange.Common;
using System;

namespace StockExchange.Events
{
    class StockMarket
    {
        public delegate void StockMarketStateHandler(StockInfo info);

        public event StockMarketStateHandler Notify;

        public void StartTrade()
        {
            var info = StockGenerator.GenerateInfo();
            WriteMessage($"\nCompany: {info.Company}, Price: {info.Price}");

            Notify?.Invoke(info);
        }

        private void WriteMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
