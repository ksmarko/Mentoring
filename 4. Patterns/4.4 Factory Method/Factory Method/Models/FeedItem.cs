using System;

namespace Factory_Method
{
    public class FeedItem
    {
        public string StagingId { get; set; }
        public string SourceTradeRef { get; set; }
        public string CounterPartyId { get; set; }
        public string PrincipalId { get; set; }
        public DateTime ValuationDate { get; set; }
        public double CurrentPrice { get; set; }
        public string SourceAccountId { get; set; }
    }

    public class DeltaOneFeedItem : FeedItem
    {
        public string Isin { get; set; }
        public string MaturityDate { get; set; }
    }

    public class EmFeedItem : FeedItem
    {
        public string Sedol { get; set; }
        public string AssetValue { get; set; }
    }
}
