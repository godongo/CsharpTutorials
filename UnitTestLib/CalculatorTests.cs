using InterviewCodingTests.Abstracts;
using InterviewCodingTests.Concretes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestLib
{
    [TestClass]
    public class CalculatorTests
    {
        ICalculator calculator;

        [TestInitialize]
        public void TestInitialize()
        {
            calculator = new Calculator();
        }

        [TestMethod]
        public void AddWillReturnSumOfTwoNumbers()
        {
            // Arrange.
            var a = 10;
            var b = 2;

            var expected = a + b;

            // Act.
            var result = calculator.Add(a, b);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
