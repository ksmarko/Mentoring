using System.Threading;

namespace StockExchange.Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            var stoskMarket = new StockMarket();
            var broker1 = new Broker("Monobank", stoskMarket);
            var broker2 = new Broker("Universal Bank", stoskMarket);
            var bank1 = new Bank("Privat Bank", stoskMarket);

            while (true)
            {
                stoskMarket.StartTrade();
                Thread.Sleep(1000);
            }
        }
    }
}
