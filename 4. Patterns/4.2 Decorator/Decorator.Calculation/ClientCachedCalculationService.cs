namespace Decorator.Calculation
{
    public class ClientCachedCalculationService : ICalculationService
    {
        private readonly ICalculationService _service;
        private const decimal ClientFactor = 10;

        public ClientCachedCalculationService(ICalculationService service)
        {
            _service = service;
        }

        public decimal Calculate(decimal firstParameter, decimal secondParameter)
        {
            return _service.Calculate(firstParameter, secondParameter) + ClientFactor;
        }
    }
}
