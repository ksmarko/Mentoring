using System.Collections.Generic;

namespace Decorator.Calculation
{
    public class CachedCalculationService : ICalculationService
    {
        private static readonly Dictionary<(decimal, decimal), decimal> Cache = new Dictionary<(decimal, decimal), decimal>();
        private readonly ICalculationService _service;

        public CachedCalculationService(ICalculationService service)
        {
            _service = service;
        }

        public decimal Calculate(decimal firstParameter, decimal secondParameter)
        {
            var key = (firstParameter, secondParameter);
            var isCached = Cache.TryGetValue(key, out var result);

            if (!isCached)
            {
                result = _service.Calculate(firstParameter, secondParameter);
                Cache.Add(key, result);
            }

            return result;
        }
    }
}
