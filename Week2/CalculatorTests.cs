using CalcLibrary;
using NUnit.Framework;

namespace StudentGrades.nUnitTests
{
    [TestFixture]
    public class CalculatorTests
    {
        private SimpleCalculator _calculator;

        [SetUp]
        public void SetUp()
        {
            _calculator = new SimpleCalculator();
        }

        [TearDown]
        public void TearDown()
        {
            _calculator = null;
        }

        [TestCase(90, 14, 104)]
        [TestCase(90, 54, 144)]
        [TestCase(50, 30, 80)] // corrected expected value
        [TestCase(0, 0, 0)]     // added edge case

        public void Addition_ShouldReturnCorrectSum(double num1, double num2, double expected)
        {
            var result = _calculator.Addition(num1, num2);
            Assert.AreEqual(expected, result);
        }

        [TestCase(50, 30, 90)]
        [TestCase(10, 30, 90)]
        [TestCase(120, 1, 130)] // incorrect expected on purpose
        [TestCase(5, 5, 15)]    // added case to fail if sum == 15

        public void Addition_ShouldNotReturnIncorrectSum(double num1, double num2, double incorrectSum)
        {
            var result = _calculator.Addition(num1, num2);
            Assert.AreNotEqual(incorrectSum, result);
        }
    }
}
