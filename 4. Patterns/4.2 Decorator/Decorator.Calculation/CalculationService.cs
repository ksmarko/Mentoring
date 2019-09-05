using System.Threading;

namespace Decorator.Calculation
{
    public class CalculationService : ICalculationService
    {
        public decimal Calculate(decimal firstParameter, decimal secondParameter)
        {
            Thread.Sleep(1000);
            return firstParameter * firstParameter + 2 * firstParameter
                   * secondParameter * secondParameter * secondParameter;
        }
    }
}
