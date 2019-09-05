using Factory.Filters;
using System;

namespace Factory
{
    public class FilterFactory : IFilterFactory
    {
        public IFilter CreateFilter(FilterType filterType)
        {
            switch (filterType)
            {
                case FilterType.BOFA:
                    return new BofaFilter();
                case FilterType.Connacord:
                    return new ConnacordFilter();
                case FilterType.Barclays:
                    return new BarclaysFilter();
                default:
                    throw new NotImplementedException("Unknown filter name.");
            }
        }
    }
}
