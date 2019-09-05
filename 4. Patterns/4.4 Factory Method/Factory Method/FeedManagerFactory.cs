using System;

namespace Factory_Method
{
    public interface IFeedManagerFactory
    {
        FeedManager CreateFeedManager(FeedType feedType);
    }

    public class FeedManagerFactory : IFeedManagerFactory
    {
        public FeedManager CreateFeedManager(FeedType feedType)
        {
            switch (feedType)
            {
                case FeedType.DeltaOne:
                    return new DeltaOneFeedManager();
                case FeedType.Em:
                    return new EmFeedManager();
                default:
                    throw new NotImplementedException("Not supported feed type");
            }
        }
    }
}
