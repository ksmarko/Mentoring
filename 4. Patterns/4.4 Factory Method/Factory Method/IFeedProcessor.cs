using System.Collections.Generic;

namespace Factory_Method
{
    public interface IFeedProcessor
    {
        IEnumerable<ValidationError> Validate(FeedItem feedItem);
        bool Match(FeedItem feedItem);
        void Save(FeedItem feedItem);
        void SaveErrors(IEnumerable<ValidationError> errors);
    }
}
