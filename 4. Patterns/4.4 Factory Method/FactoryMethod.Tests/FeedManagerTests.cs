using Factory_Method;
using FluentAssertions;
using NUnit.Framework;
using System;

namespace FactoryMethod.Tests
{
    public class FeedManagerTests
    {
        [Test]
        [TestCase(FeedType.Em, typeof(EmFeedManager))]
        [TestCase(FeedType.DeltaOne, typeof(DeltaOneFeedManager))]
        public void Can_return_correct_manager_for_FeedType(FeedType type, Type expectedType)
        {
            var factory = new FeedManagerFactory();

            var manager = factory.CreateFeedManager(type);

            manager.Should().BeOfType(expectedType);
        }

        [Test]
        [TestCase(FeedType.Em, typeof(EmFeedProcessor))]
        [TestCase(FeedType.DeltaOne, typeof(DeltaOneFeedProcessor))]
        public void Manager_should_return_correct_processor(FeedType type, Type expectedType)
        {
            var factory = new FeedManagerFactory();

            var manager = factory.CreateFeedManager(type);

            manager.FeedProcessor.Should().BeOfType(expectedType);
        }
    }
}
