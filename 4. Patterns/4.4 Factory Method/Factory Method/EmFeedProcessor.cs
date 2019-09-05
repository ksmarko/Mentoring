using System;
using System.Collections.Generic;

namespace Factory_Method
{
    public class EmFeedProcessor : IFeedProcessor
    {
        public IEnumerable<ValidationError> Validate(FeedItem feedItem)
        {
            var errors = new List<ValidationError>();

            if (string.IsNullOrEmpty(feedItem.SourceAccountId))
                errors.Add(new ValidationError($"Em feedItem. {nameof(feedItem.SourceAccountId)} cannot be null or empty"));

            return errors;
        }

        public bool Match(FeedItem feedItem)
        {
            //just for demonstration purposes
            return new Random().Next(0, 100) % 2 == 0;
        }

        public void Save(FeedItem feedItem)
        {
            Console.WriteLine($"Em feed item #{feedItem.SourceAccountId} has been saved");
        }

        public void SaveErrors(IEnumerable<ValidationError> errors)
        {
            foreach (var error in errors)
            {
                Console.WriteLine(error.Message);
            }
        }
    }
}
