using System;
using System.Collections.Generic;

namespace Factory_Method
{
    public class DeltaOneFeedProcessor : IFeedProcessor
    {
        public IEnumerable<ValidationError> Validate(FeedItem feedItem)
        {
            var errors = new List<ValidationError>();

            if (string.IsNullOrEmpty(feedItem.CounterPartyId))
                errors.Add(new ValidationError($"DeltaOne feed item. {nameof(feedItem.CounterPartyId)} cannot be null or empty"));

            if (string.IsNullOrEmpty(feedItem.PrincipalId))
                errors.Add(new ValidationError($"DeltaOne feed item. {nameof(feedItem.PrincipalId)} cannot be null or empty"));

            return errors;
        }

        public bool Match(FeedItem feedItem)
        {
            //just for demonstration purposes
            return new Random().Next(0, 100) % 3 == 0;
        }

        public void Save(FeedItem feedItem)
        {
            Console.WriteLine($"DeltaOne feed item #{feedItem.CounterPartyId}-{feedItem.PrincipalId} has been saved");
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
