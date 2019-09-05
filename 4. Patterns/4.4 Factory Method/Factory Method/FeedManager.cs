using System.Collections.Generic;
using System.Linq;

namespace Factory_Method
{
    public abstract class FeedManager
    {
        public abstract IFeedProcessor FeedProcessor { get; }
        public void Process(IEnumerable<FeedItem> feedItems)
        {
            foreach (var item in feedItems)
            {
                var errors = FeedProcessor.Validate(item);

                if (errors.Any())
                {
                    FeedProcessor.SaveErrors(errors);
                    continue;
                }

                if (FeedProcessor.Match(item))
                    FeedProcessor.Save(item);
            }
        }
    }

    public class DeltaOneFeedManager : FeedManager
    {
        public override IFeedProcessor FeedProcessor => new DeltaOneFeedProcessor();
    }

    public class EmFeedManager : FeedManager
    {
        public override IFeedProcessor FeedProcessor => new EmFeedProcessor();
    }
}
