using System;
using System.Linq;
using AutoFixture;
using Factory_Method;

namespace FactoryMethod.Program
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new FeedManagerFactory();
            var feedItems = new Fixture().CreateMany<FeedItem>(10);

            // for getting errors
            feedItems.First().PrincipalId = null;
            feedItems.Last().SourceAccountId = null;

            var deltaOneManager = factory.CreateFeedManager(FeedType.DeltaOne);
            deltaOneManager.Process(feedItems);

            var emManager = factory.CreateFeedManager(FeedType.Em);
            emManager.Process(feedItems);

            Console.ReadKey();
        }
    }
}
