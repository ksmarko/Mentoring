using System;

namespace StockExchange.Common
{
    public class StockGenerator
    {
        public static StockInfo GenerateInfo()
        {
            return new StockInfo()
            {
                Company = GetCompany(),
                Price = GetPrice()
            };
        }

        private static string GetCompany()
        {
            var index = new Random().Next(0, Companies.Length - 1);
            return Companies[index];
        }

        private static double GetPrice()
        {
            return Math.Round(new Random().Next(10000) * 0.1, 2);
        }

        private static readonly string[] Companies = new[]
        {
            "Microsoft",
            "Apple",
            "Google",
            "Tesla Motors",
            "Facebook",
            "Twitter",
            "U. S."
        };
    }
}
