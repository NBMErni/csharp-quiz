using System.Diagnostics.Metrics;
using System.Numerics;

namespace CalculatorApp;

class Program
{
    static void Main(string[] args)
    {

        try
        {


            Console.WriteLine("Enter the first number:");
            double num1 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter the second number:");
            double num2 = Convert.ToDouble(Console.ReadLine());

            if (num1.GetType() == typeof(string) || num2.GetType() == typeof(string))
            {
                throw new FormatException("Please enter numeric values.");
            }


            Console.WriteLine("Enter the operation (add, subtract, multiply, divide):");
            string operation = Console.ReadLine()?.ToLower() ?? string.Empty;

            var calculator = new Calculator();
            double result = calculator.PerformOperation(num1, num2, operation);
            Console.WriteLine($"The result is: {result}");


        }
        catch (FormatException ex)
        {
            Console.WriteLine($"Invalid input: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("Calculation attempt finished.");
        }


    }
}