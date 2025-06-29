using CalcLibrary;

namespace StudentGrades.nUnitTests
{
    [TestFixture]
    public class CalculatorTests
    {
        private SimpleCalculator calculator;

        [SetUp]
        public void Setup()
        {
           calculator = new SimpleCalculator();
        }

        public void TearDown()
        {
            calculator = null;
        }

        [TestCase(90, 14,104)]
        [TestCase(90, 54, 144)]
        [TestCase(50, 30, 90)]
        [TestCase(10, 30, 20)]

        public void Addition_EqualTest(double a, double b, double expected)
       {
            var actual = calculator.Addition(a, b);
            Assert.AreEqual(expected, actual);
       }

        [TestCase(50,30,90)]
        [TestCase(10, 30, 90)]
        [TestCase(120, 1, 121)]
        [TestCase(50, 80, 130)]

        public void Addition_NotEqualTest(double a, double b, double Notexpected)
        {
            var actual = calculator.Addition(a, b);
            Assert.AreNotEqual(Notexpected, actual);
        }
    }
}
