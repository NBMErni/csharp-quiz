using NUnit.Framework;
using static CalculatorApp.LoggerProvider;

namespace CalculatorApp.UnitTests
{
    [TestFixture]
    public class CalculatorTest
    {
        private Calculator _calculator;

        [SetUp]
        public void SetUp()
        {
            _calculator = new Calculator(CreateLogger<Calculator>());
        }

        [TestCase(3, 5, "add")]
        public void Add_Inputs_ShouldReturnResult(double expectedNum1, double expectedNum2, string expectedOperation)
        {

            // ACT
            double result = _calculator.PerformOperation(expectedNum1, expectedNum2, expectedOperation);

            // ASSERT
            Assert.That(result, Is.EqualTo(8));
        }

        [TestCase(5, 3, "subtract")]
        public void Subtract_Inputs_ShouldReturnResult(double expectedNum1, double expectedNum2, string expectedOperation)
        {

            // ACT
            double result = _calculator.PerformOperation(expectedNum1, expectedNum2, expectedOperation);

            // ASSERT
            Assert.That(result, Is.EqualTo(2));
        }

        [TestCase(5, 3, "multiply")]
        public void Multiply_Inputs_ShouldReturnResult(double expectedNum1, double expectedNum2, string expectedOperation)
        {

            // ACT
            double result = _calculator.PerformOperation(expectedNum1, expectedNum2, expectedOperation);

            // ASSERT
            Assert.That(result, Is.EqualTo(15));
        }

        [TestCase(6, 3, "divide")]
        public void Divide_Inputs_ShouldReturnResult(double expectedNum1, double expectedNum2, string expectedOperation)
        {

            // ACT
            double result = _calculator.PerformOperation(expectedNum1, expectedNum2, expectedOperation);

            // ASSERT
            Assert.That(result, Is.EqualTo(2));
        }

        [TestCase("5", "0", "divide")]
        public void DivideByZero_Inputs_ShouldReturnFailure(double expectedNum1, double expectedNum2, string expectedOperation)
        {



            // ASSERT
            var ex = Assert.Throws<DivideByZeroException>(() => _calculator.PerformOperation(expectedNum1, expectedNum2, expectedOperation));
            Assert.That(ex.Message, Is.EqualTo("Cannot divide by zero."));

        }

        [TestCase(5, 0, "modulo")]
        public void MethodUnderTest_Scenario_ExpectedBehavior(double expectedNum1, double expectedNum2, string expectedOperation)
        {
            var ex = Assert.Throws<InvalidOperationException>(() => _calculator.PerformOperation(expectedNum1, expectedNum2, expectedOperation));
            Assert.That(ex.Message, Is.EqualTo("The specified operation is not supported."));
        }

        [TestCase("abc", "def", "add")]
        public void String_Inputs_ShouldReturnFailure(string expectedNum1, string expectedNum2, string expectedOperation)
        {

            // ACT

            var ex = Assert.Throws<FormatException>(() => _calculator.PerformOperation(Convert.ToDouble(expectedNum1), Convert.ToDouble(expectedNum2), expectedOperation));
            Assert.That(ex.Message, Is.EqualTo($"The input string '{expectedNum1}' was not in a correct format."));

        }
    }
}
