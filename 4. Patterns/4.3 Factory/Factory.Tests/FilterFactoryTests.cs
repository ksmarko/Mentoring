using AutoFixture;
using Factory.Models;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Factory.Filters;

namespace Factory.Tests
{
    public class FilterFactoryTests
    {
        private List<Trade> _trades;

        [OneTimeSetUp]
        public void SetUp()
        {
            var fixture = new Fixture();

            _trades = fixture.CreateMany<Trade>(100).ToList();
        }

        [Test]
        public void Should_return_trades_with_Amount_equal_or_greater_then_70_for_BOFA_bank()
        {
            var sut = new FilterFactory();

            var filteredTrades = sut.CreateFilter(FilterType.BOFA).Match(_trades);

            filteredTrades.Should().OnlyContain(x => x.Amount >= 70);
        }

        [Test]
        public void Should_return_trades_with_Amount_between_10_and_40_and_Future_TradeType_for_Connacord_bank()
        {
            var sut = new FilterFactory();

            var filteredTrades = sut.CreateFilter(FilterType.Connacord).Match(_trades);

            filteredTrades.Should().OnlyContain(x => x.Amount > 10 && x.Amount < 40 && x.Type == TradeType.Future);
        }

        [Test]
        public void Should_return_trades_with_Amount_greater_than_50_and_Option_TradeType_and_NyOption_TradeSubType_for_Barclays_bank()
        {
            var sut = new FilterFactory();

            var filteredTrades = sut.CreateFilter(FilterType.Barclays).Match(_trades);

            filteredTrades.Should().OnlyContain(x => x.Amount >= 50 && x.SubType == TradeSubType.NyOption && x.Type == TradeType.Option);
        }
    }
}
