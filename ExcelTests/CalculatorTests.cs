using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Excel.Tests
{
    [TestClass()]
    public class CalculatorTests
    {

        public void Compare(string expression, double expected)
        {
            double actual = Calculator.Evaluate(expression);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Evaluate_UnaryOperatorsWithParenthesis_CorrectResult()
        {
            string expression = "---(1+++2)";
            Compare(expression, -3);
        }

        [TestMethod()]
        public void Evaluate_ModOperator_CorrectResult()
        {
            string expression = "mod(3, 4)";
            Compare(expression, 3);
        }

        [TestMethod()]
        public void Evaluate_DivOperator_CorrectResult()
        {
            string expression = "div(13, 4)";
            Compare(expression, 3);
        }
    }
}