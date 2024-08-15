using Microsoft.Extensions.Logging;

namespace CalculatorApp
{
    public class Calculator
    {
        private readonly ILogger<Calculator> _logger;
        public Calculator(ILogger<Calculator> logger)
        {
            _logger = logger;
        }

        public double PerformOperation(double num1, double num2, string operation)
        {


            switch (operation)
            {
                case "add":
                    return num1 + num2;

                case "subtract":
                    return num1 - num2;

                case "multiply":
                    return num1 * num2;

                case "divide":
                    if (num2 == 0)
                    {
                        _logger.LogError("Cannot divide by zero.");
                        throw new DivideByZeroException("Cannot divide by zero.");
                    }
                    return num1 / num2;

                default:
                    _logger.LogError("The specified operation is not supported.");
                    throw new InvalidOperationException("The specified operation is not supported.");
            }
        }
    }
}
