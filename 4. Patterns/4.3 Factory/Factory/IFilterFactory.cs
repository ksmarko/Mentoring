using Factory.Filters;

namespace Factory
{
    public interface IFilterFactory
    {
        IFilter CreateFilter(FilterType filterType);
    }
}
