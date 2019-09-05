namespace Factory.Models
{
    public class Trade
    {
        public int Amount { get; set; }
        public TradeType Type { get; set; }
        public TradeSubType SubType { get; set; }
    }

    public enum TradeType
    {
        Future = 0,
        Option = 1
    }

    public enum TradeSubType
    {
        NyFuture = 0,
        NyOption = 1
    }
}
