using Microsoft.Extensions.Logging;
using static CalculatorApp.LoggerProvider;

namespace CalculatorApp;

class Program
{
    static void Main(string[] args)
    {
        var logger = CreateLogger<Program>();

        try
        {
            Console.WriteLine("Enter the first number:");
            double num1 = Convert.ToDouble(Console.ReadLine());
            logger.LogInformation($"num1 is {num1}");

            Console.WriteLine("Enter the second number:");
            double num2 = Convert.ToDouble(Console.ReadLine());

            if (num1.GetType() == typeof(string) || num2.GetType() == typeof(string))
            {
                logger.LogError("Please enter numeric values.");
                throw new FormatException("Please enter numeric values.");
            }

            Console.WriteLine("Enter the operation (add, subtract, multiply, divide):");
            string operation = Console.ReadLine()?.ToLower() ?? string.Empty;

            var calculator = new Calculator(CreateLogger<Calculator>());
            double result = calculator.PerformOperation(num1, num2, operation);
            Console.WriteLine($"The result is: {result}");


        }
        catch (FormatException ex)
        {
            logger.LogError($"Invalid input: Please enter a numeric values.");
            Console.WriteLine($"Invalid input: Please enter a numeric values.");


        }
        catch (Exception ex)
        {
            logger.LogError($"Error: {ex.Message}");
            Console.WriteLine($"Error: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("Calculation attempt finished.");
        }
    }
}